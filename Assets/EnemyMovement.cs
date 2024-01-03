using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    //public Transform Player;
    private GameObject target;
    public float UpdateRate = 0.1f;
    private NavMeshAgent Agent;
    private Transform _transform;
    
    private float dist;
    private void Awake()
    {
        _transform = transform;
        Agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        dist = Vector2.Distance(_transform.position, target.transform.position);

        if (dist >= 1)
            StartCoroutine(FollowTarget());
        else StopCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
        
        while(enabled)
        {
            Agent.SetDestination(target.transform.position);
            yield return Wait;
        }
    }
}
