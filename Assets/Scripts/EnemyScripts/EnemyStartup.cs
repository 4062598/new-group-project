using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStartup : MonoBehaviour
{
    [SerializeField] private float MaxDistanceToNavMesh = 2.0f;

    void Start()
    {
        Invoke("delayAddingScript", 1.5f);
    }

    void delayAddingScript()
    {
        //out value to store result if a navmesh is found
        NavMeshHit hit;

        //check if there is a navmesh within the max distance
        if (NavMesh.SamplePosition(transform.position, out hit, MaxDistanceToNavMesh, NavMesh.AllAreas))
        {
            // snap object to navmesh if it is close enough
            transform.position = hit.position;

            //add navmesh and ai script
            gameObject.AddComponent<NavMeshAgent>();
            gameObject.AddComponent<NewEnemyAI>();
            Destroy(GetComponent<Rigidbody>());
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} is too far from NavMesh and has been destroyed");
            Destroy(gameObject);
        }
    }
}
