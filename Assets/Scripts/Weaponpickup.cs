using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponpickup : MonoBehaviour
{
    bool hit = false;
     private WeaponSwitching weaponswitching;
    //private Shotgun shotgun;
    public int weapongained;

    private void Start()
    {
        weaponswitching = GameObject.FindGameObjectWithTag("WeaponHolder").GetComponent<WeaponSwitching>();
        //shotgun = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<Shotgun>();
    }
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
            weaponswitching.GainWeapon(weapongained);
            //shotgun.WeaponAcquired(true);
            Destroy(gameObject);
            hit = false;
        }
    }
}
