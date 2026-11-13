using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;
    public float damage = 10f; // damage gun does
    public float range = 100f; // How far we can shoot
    public Camera fpsCam;
    // Add this field to the Gun class
    public ParticleSystem muzzleFlash;

    // visible bullet
    public GameObject bulletPrefab; 
    public Transform gunBarrelTip;   
    public float bulletSpeed = 120f; // how fast it goes

    private void Awake()
    {
        controls = new CharacterInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {

    }

    void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.transform.position = transform.position;
            muzzleFlash.transform.rotation = transform.rotation;
            muzzleFlash.Play();
        }

        // Bullet spawn logic??
        if (bulletPrefab != null && gunBarrelTip != null)
        {
            // spawn bullet model
            GameObject bullet = Instantiate(bulletPrefab, gunBarrelTip.position, gunBarrelTip.rotation);

            // shoots the bullet out straight foward
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = gunBarrelTip.forward * bulletSpeed;
            }

            //destroys the bullet after 2 seconds so the game doesn't lag
            Destroy(bullet, 2f);
        }

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * hit.distance, Color.red, 1f);

            Debug.Log(hit.transform.name);

            Target enemy = hit.transform.GetComponent<Target>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.Player.Shoot.triggered)
        {
            Shoot();
        }
    }
}
