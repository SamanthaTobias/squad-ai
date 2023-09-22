using UnityEngine;

public class FollowMouseClickStrategy : ISoldierStrategy
{
    private readonly Soldier soldier;

    private Vector2 targetPosition;
    private ISoldierTactic moveTactic;
    private readonly ISoldierTactic reachedGoalTactic;

    public FollowMouseClickStrategy(Soldier soldier)
    {
        this.soldier = soldier;
        reachedGoalTactic = new StandGuardTactic(soldier);
        moveTactic = reachedGoalTactic;
    }

    public void Update()
    {
        HandleInput();

        if (HasReachedTargetPosition())
        {
            reachedGoalTactic.Update();
        }
        else
        {
            moveTactic.Update();
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(soldier.name + " has a new target position: " + targetPosition);
            moveTactic = new MoveToPositionTactic(soldier, targetPosition);
        }
    }

    private bool HasReachedTargetPosition()
    {
        return Vector2.Distance(soldier.transform.position, targetPosition) < 0.1f;
    }
}
