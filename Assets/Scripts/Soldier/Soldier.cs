using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public string Name => "Unknown Soldier";

    public float Speed { get; } = 10.0f;
    private IWeapon weapon;
    private ISoldierStrategy strategy;

    // Start is called before the first frame update
    void Start()
    {
        strategy = new FollowMouseClickStrategy(this);
        Debug.Log(Name + " initialized with strategy: " + strategy.GetType().Name);
    }

    // Update is called once per frame
    void Update()
    {
        strategy.Update();
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

    public void MoveTowardsPosition(Vector2 position)
    {
        Vector2 direction = position - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, position, Speed * Time.deltaTime);
    }
}
