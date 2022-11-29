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


    public override void PerformAction(SubmarineController submarine, AiDetector detector)
    {
        float angle = Vector2.Angle(submarine.aimTurret.transform.right, randomDirection);
        Vector2 directionToGo = Vector2.zero;

        if(detector.Target != null && detector.TargetVisible != null)
        {
            directionToGo = detector.Target.position - submarine.submarineMover.transform.position;
            submarine.HandleMoveEnemy(detector.Target.position, submarine.submarineMover.transform.position);
            //submarine.HandleMoveBody(directionToGo);
        } else {
            submarine.HandleMoveBody(Vector2.zero);
        }
    }
}
