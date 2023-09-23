using UnityEngine;

public class MoveToPositionTactic : ISoldierTactic
{
    private readonly Soldier soldier;
    private readonly Vector2 targetPosition;

    public MoveToPositionTactic(Soldier soldier, Vector2 targetPosition)
    {
        this.soldier = soldier;
        this.targetPosition = targetPosition;
    }

    public void Update()
    {
        soldier.MoveTowardsPosition(targetPosition);
    }
}
