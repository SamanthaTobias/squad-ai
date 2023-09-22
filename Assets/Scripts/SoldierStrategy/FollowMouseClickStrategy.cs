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
        moveTactic = null;
        reachedGoalTactic = new StandGuardTactic(soldier);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(soldier.name + " has a new target position: " + targetPosition);
            moveTactic = new MoveToPositionTactic(soldier, targetPosition);
        }

        if (moveTactic == null || HasReachedTargetPosition())
        {
            reachedGoalTactic.Update();
        }
        else
        {
            moveTactic.Update();
        }
    }

    private bool HasReachedTargetPosition()
    {
        return (Vector2)soldier.transform.position == targetPosition;
    }
}
