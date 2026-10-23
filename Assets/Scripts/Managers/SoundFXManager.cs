using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager: MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Spawn gameObj
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign audioClip
        audioSource.clip = audioClip;

        //assign volume 
        audioSource.volume = volume;

        //Play sound
        audioSource.Play();

        //get length of sound
        float clipLength = audioSource.clip.length;

        //destroy gameobj
        Destroy(audioSource.gameObject, clipLength);

    }
    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        if (audioClip == null || audioClip.Length == 0)
        {
            return; // Exit if there are no soundclips 
        }
        //assign random index
        int rand = Random.Range(0, audioClip.Length);

        //Spawn gameObj
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign audioClip
        audioSource.clip = audioClip[rand];

        //assign volume 
        audioSource.volume = volume;

        //Play sound
        audioSource.Play();

        //get length of sound
        float clipLength = audioSource.clip.length;

        //destroy gameobj
        Destroy(audioSource.gameObject, clipLength);

    }
}
