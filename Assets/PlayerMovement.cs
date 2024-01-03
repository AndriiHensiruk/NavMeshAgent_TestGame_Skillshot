using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera Camera = null;
    private NavMeshAgent Agent;
    bool isActive = false;
    public float UpdateRate = 0.1f;
    Renderer renderer;
    private GameObject target;

    private RaycastHit[] Hits = new RaycastHit[1];

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseDown()
    {
        isActive = true;
        renderer.material.color = Color.green;

    }

    private void Move()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.RaycastNonAlloc(ray, Hits) > 0)
            {
                Agent.SetDestination(Hits[0].point);

            }

        }
    }

    private void Update()
    {
        if (isActive)
        {
            Move();
        }


    }

}
