using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public bool followClicks = false;
    public Vector2 targetLocation;

    private bool hasTarget = false;
    private float speed = 0.0f;
    private float speedMax = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Soldier who is" + (followClicks ? " not " : " ") + "following clicks");
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
                if (speed < speedMax)
                {
                    speed = Mathf.Lerp(speed, speedMax, Time.deltaTime);
                }

                transform.position = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
            }
            else
            {
                speed = 0.0f;
                hasTarget = false;
            }
        }
    }
}
