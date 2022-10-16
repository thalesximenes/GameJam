using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeafaultEnemyAI : MonoBehaviour
{
    [SerializeField]
    private AiBehavior shootBehavior, patrolBehavior;

    [SerializeField]
    private SubmarineController submarine;
    [SerializeField]
    private  AiDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AiDetector>();
        submarine = GetComponentInChildren<SubmarineController>();
    }

    private void Update() {
        if (detector.TargetVisible)
        {
            shootBehavior.PerformAction(submarine, detector);
        } else 
        {
            patrolBehavior.PerformAction(submarine, detector);
        }
    }

}
