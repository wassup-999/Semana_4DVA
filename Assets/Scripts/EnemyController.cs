using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = (Random.Range(1.5f, 4f));
    }

    
    void Update()
    {
        if (!agent.hasPath) 
        {
            Debug.Log("No existe camino");               
        }
        if(Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
