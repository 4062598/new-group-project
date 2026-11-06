using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour
{
    private SafeGroundSaver safeGroundSaver;

    private void Start()
    {
        safeGroundSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeGroundSaver>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player fall damage");
            GameManager.instance.ChangeHealth(20f);
            safeGroundSaver.WarpPlayerToSafeGround();
        }
        else 
        {

        }
    }
}