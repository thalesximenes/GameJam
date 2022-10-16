using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewTankMovementData", menuName="Data/SubmarineMovementData")]
public class SubmarineMovementData : ScriptableObject
{
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    public float acceleration = 100;
    public float deacceleration = 100;
}
