using UnityEngine;
using System.Collections;

public class KillZoneScript : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}