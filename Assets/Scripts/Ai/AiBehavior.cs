using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBehavior : MonoBehaviour
{
    public abstract void PerformAction(SubmarineController submarine, AiDetector detector);
}
