using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player; // The target to follow
    private NavMeshAgent navMeshAgent; // The NavMeshAgent component


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 

    }

    // Update is called once per frame
    void Update()
    {
     
        if(player != null)
        {
            // Set the destination of the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);
        }

    }
}
