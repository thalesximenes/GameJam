using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootBehavior : AiBehavior
{
    public float fieldOfVisionForShooting = 60;

    public override void PerformAction(SubmarineController submarine, AiDetector detector)
    {
        if (TargetInFOV(submarine, detector))
        {
            submarine.HandleMoveBody(Vector2.zero);
            submarine.HandleShoot();
        }submarine.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(SubmarineController submarine, AiDetector detector)
    {
        var direction = detector.Target.position - submarine.aimTurret.transform.position;
        if (Vector2.Angle(submarine.aimTurret.transform.right, direction) < fieldOfVisionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
