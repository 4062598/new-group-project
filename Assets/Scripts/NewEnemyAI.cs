using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NewEnemyAI : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3f;
        agent.stoppingDistance = 2.5f;

        player = GameObject.Find("Player").transform;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
       if(agent != null)
            agent.SetDestination(player.position);
        
    }
}
