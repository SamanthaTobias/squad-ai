using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public bool followClicks;
    public Vector2 targetLocation;
    public string Name => "Unknown Soldier";

    private bool hasTarget = false;
    private float speed = 10.0f;  // Constant speed
    private IWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Soldier who is" + (followClicks ? " " : " not ") + "following clicks");
    }

    // Update is called once per frame
    void Update()
    {
        if (followClicks && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetLocation = mousePos;
            hasTarget = true;
        }

        if (hasTarget)
        {
            if ((Vector2)transform.position != targetLocation)
            {
                // Update rotation instantly
                Vector2 direction = targetLocation - (Vector2)transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;  // -90 to align with the up direction
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                // Update position
                transform.position = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
            }
            else
            {
                hasTarget = false;
                Debug.Log(this.Name + " found a weapon at the target location.");
                EquipWeapon(new M1Garand());
            }
        }
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
