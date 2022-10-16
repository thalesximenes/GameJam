using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDetector : MonoBehaviour
{

    [SerializeField]
    private float viewRadius = 41;
    [SerializeField]
    private float attackRadius = 2;
    [SerializeField]
    private float detectionCheckDelay = 0.1f;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityLayer;

    [field: SerializeField]
    public bool TargetVisible {get; private set;}
    [field: SerializeField]
    public bool TargetAttackable {get; private set;}
    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisible = false;
            TargetAttackable = false;
        }
    }

    private void Start() {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update() {
        if (Target != null)
            TargetVisible = CheckTargetVisible();
            TargetAttackable = CheckIfPlayerInAttackRange();
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void DetectTarget()
    {
        if (Target == null)
            CheckIfPlayerInRange();
        else if (Target != null)
            DetectIfOutOfRange();
    }

    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position, Target.position) > viewRadius)
        {
            Target = null;
        }
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

     private bool CheckIfPlayerInAttackRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, attackRadius, playerLayerMask);
        if (collision != null)
        {
            return true;
        }
        return false;
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,viewRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRadius);    
    }

}
