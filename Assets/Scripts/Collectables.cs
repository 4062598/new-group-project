using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour

{

    bool hit = false;
    public int scoreValue = 1;
    [SerializeField] private AudioClip[] CollectableSounds;


    void OnTriggerEnter(Collider other)

    {

        //Check if the collider's parent has the tag Player

        if (other.transform.root.CompareTag("Player"))

        {
            
            hit = true;

        }

    }



    // Update is called once per frame

    void Update()

    {

        if (hit == true)

        {

            GameManager.instance.ChangeScore(scoreValue);
            SoundFXManager.instance.PlayRandomSoundFXClip(CollectableSounds, transform, 1f);
            Destroy(gameObject);
            hit = false;
        }

    }

}