using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolStaticBehavior : AiBehavior
{
    public float patrolDelay = 4;

    [SerializeField]
    private Vector2 randomDirection = Vector2.zero;
    [SerializeField]
    private float currentPatrolDelay;

    private void Awake() 
    {
        randomDirection = Random.insideUnitCircle;    
    }

    public override void PerformAction(SubmarineController submarine, AiDetector detector)
    {
        float angle = Vector2.Angle(submarine.aimTurret.transform.right, randomDirection);
        if (currentPatrolDelay <= 0 && (angle < 2))
        {
            randomDirection = Random.insideUnitCircle;
        }
        else
        {
            if (currentPatrolDelay > 0)
                currentPatrolDelay -= Time.deltaTime;
            else
                submarine.HandleTurretMovement((Vector2)submarine.aimTurret.transform.position + randomDirection);
        }
    }
}
