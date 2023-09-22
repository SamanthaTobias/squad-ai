using UnityEngine;

public class StandGuardTactic : ISoldierTactic
{
    private readonly Soldier soldier;
    private float timer = 0f;
    private float nextRotationTime = 0f;
    private float rotationAngle;

    public StandGuardTactic(Soldier soldier)
    {
        this.soldier = soldier;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextRotationTime)
        {
            // Randomly decide the direction of rotation
            int direction = Random.Range(0, 2) == 0 ? 1 : -1;

            // Rotate the soldier
            rotationAngle = Random.Range(45f, 180f) * direction;
            soldier.transform.Rotate(0, 0, rotationAngle);
            Debug.Log(soldier.Name + " is rotating while standing guard.");

            // Reset the timer and set the next rotation time
            timer = 0f;
            SetNextRotationTime();
        }
    }

    private void SetNextRotationTime()
    {
        nextRotationTime = Random.Range(3f, 5f);
    }
}
