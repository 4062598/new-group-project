using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStartup : MonoBehaviour
{
   // public Transform ground; // Ground check empty goes in here
   // public float distanceToGround = 0.4f; // How close the ground needs to be to register
   // public LayerMask groundMask; // What layer is ground?
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delayAddingScript", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private bool isGrounded()
    //{
   //     return Physics.CheckSphere(ground.position, distanceToGround, groundMask);
   // }
    void delayAddingScript()
    {
        //gameObject.AddComponent<NavMeshAgent>();
         //if (isGrounded())
        /// {
        gameObject.AddComponent<NavMeshAgent>();
       // }
        gameObject.AddComponent<NewEnemyAI>();
        Destroy(GetComponent<Rigidbody>());
    }
}
