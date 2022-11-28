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
    private float count = 0;

    private void Awake()
    {
        detector = GetComponentInChildren<AiDetector>();
        submarine = GetComponentInChildren<SubmarineController>();
    }

    private void Update() {
        if ((detector.TargetVisible && detector.TargetAttackable) || count > 0 )
        {
            if (count < 0) count = 3;

            shootBehavior.PerformAction(submarine, detector);
            count-= Time.deltaTime;
        } else 
        {
            patrolBehavior.PerformAction(submarine, detector);
        }
    }

}
