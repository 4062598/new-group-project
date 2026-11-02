using UnityEngine;
using System.Collections;

public class KillZoneScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
        else if (other.transform.root.CompareTag("Player")) 
        {
            Debug.Log("hit");
        }
    }
}