using UnityEngine;
using System.Collections;

public class OutOfBoundsBarrier : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player fall damage");
        }
        else 
        {
            Destroy(other.gameObject);
        }
    }
}