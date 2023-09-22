using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Vector2 TargetLocation { get; set; }
    public bool HasTarget { get; set; }
    public string Name => "Unknown Soldier";

    private float speed = 10.0f;  // Constant speed
    private IWeapon weapon;
    private ISoldierStrategy strategy;

    // Start is called before the first frame update
    void Start()
    {
        strategy = new FollowMouseClickStrategy();  // Initialize with the strategy you'd like to use
        Debug.Log(Name + " initialized with strategy: " + strategy.GetType().Name);
    }

    // Update is called once per frame
    void Update()
    {
        // Use the strategy to handle input
        strategy.HandleInput(this);

        if (HasTarget)
        {
            // Update the Soldier's position
            if ((Vector2)transform.position != TargetLocation)
            {
                MoveTowardsTarget();
            }
            else
            {
                HasTarget = false;

                // Use the strategy to handle reaching the target
                strategy.HandleTargetReached(this);
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // Similar to your original code
        Vector2 direction = TargetLocation - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, TargetLocation, speed * Time.deltaTime);
    }

    public void EquipWeapon(IWeapon weapon)
    {
        if (this.weapon != null)
        {
            Debug.Log(this.Name + " throws his " + this.weapon.Name + " into the void.");
        }
        this.weapon = weapon;
        Debug.Log(this.Name + " equips a " + weapon.Name);
    }
}
