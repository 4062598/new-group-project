using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float health = 50f;
    public float damage = 10f;
    bool hit = false;
    [SerializeField] AudioClip[] PlayerHurtSoundClips;

    //Start is called before the first frame update
   
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(health);
        if (other.transform.root.CompareTag("Player"))
        {
            SoundFXManager.instance.PlayRandomSoundFXClip(PlayerHurtSoundClips, transform, 1f);
            hit = true;

        }
    }
    //Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            GameManager.instance.Changehealth(damage);
            hit = false;
        }
    }

   


}
