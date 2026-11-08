using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNails : MonoBehaviour
{
    bool hit = false;
    public int scoreValue;
    [SerializeField] private AudioClip[] CollectableSounds;
    private Gunthree nailgun;

    private void Start()
    {
        nailgun = GameObject.FindGameObjectWithTag("Nailgun").GetComponent<Gunthree>();
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
            nailgun.ChangeAmmoCount(scoreValue);
            //SoundFXManager.instance.PlayRandomSoundFXClip(CollectableSounds, transform, 1f);


            Destroy(gameObject);
            hit = false;

        }

    }
}
