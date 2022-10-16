using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    public SubmarineMover submarineMover;
    public AimTurret aimTurret;
    public Turret[] turrets;

    private void Awake() 
    {
        if(submarineMover == null)
            submarineMover = GetComponentInChildren<SubmarineMover>();
        
        if(aimTurret == null)
            aimTurret = GetComponentInChildren<AimTurret>();
        
        if(turrets == null || turrets.Length == 0)
        {       
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        submarineMover.Move(movementVector);
    }

    public void HandleTurretMovement (Vector2 pointerPosition)
    {
        aimTurret.Aim(pointerPosition);
    } 
}
