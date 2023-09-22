using UnityEngine;

public class FollowMouseClickStrategy : ISoldierStrategy
{
    public void HandleInput(Soldier soldier)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            soldier.TargetLocation = mousePos;
            soldier.HasTarget = true;
        }
    }

    public void HandleTargetReached(Soldier soldier)
    {
        Debug.Log(soldier.Name + " found a weapon at the target location.");
        soldier.EquipWeapon(new M1Garand());
    }
}
