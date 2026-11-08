using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableShells : MonoBehaviour
{
    bool hit = false;
    public int scoreValue;
    [SerializeField] private AudioClip[] CollectableSounds;
    private Shotgun shotgun;
    
    private void Start()
    {
        shotgun = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<Shotgun>();
    }
    void OnTriggerEnter(Collider other)

    {

        //Check if the collider's parent has the tag Player

        if (other.transform.root.CompareTag("Player"))

        {

            
            hit = true;

        }



        // Update is called once per frame

       
    }
    void Update()
    {
         if (hit == true)

         {
            Debug.Log("yep this is working");
            shotgun.ChangeAmmoCount(scoreValue);
            //SoundFXManager.instance.PlayRandomSoundFXClip(CollectableSounds, transform, 1f);
            
           
            Destroy(gameObject);
            hit = false;
            
        } 

    }
}
