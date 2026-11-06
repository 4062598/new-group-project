using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Shotgun : MonoBehaviour
{
    private CharacterInput controls;
    public float damage = 10f;
    public float range = 100f;//how far we can shoot
    [SerializeField] float _fireRate;
    float _timeSinceFired;
    public Camera fpsCam;

    [SerializeField] bool FullAuto = false;
    [SerializeField] int bulletsPerShot = 6;

    [SerializeField] float inaccuracyDistance = 5f;
    [SerializeField] int maxAmmo;
    int currentAmmo;
    public TextMeshProUGUI AmmoText;
    [SerializeField] float RecoilKickBack = 0.08f;
    [SerializeField] float RecoilKickUp = 6.0f;
    [SerializeField] float RecoilReturnSpeed = 8.0f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        controls = new CharacterInput();
        currentAmmo = maxAmmo;
        
        AmmoText.text = "Ammo:" + currentAmmo.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (controls.Player.Shoot.triggered && !FullAuto && Time.time > _timeSinceFired && CanShoot())
        {
            Shoot();
            _timeSinceFired = Time.time + _fireRate;
        }
        if (controls.Player.Shoot.inProgress && FullAuto && Time.time > _timeSinceFired && CanShoot())
        {
            Shoot();
            _timeSinceFired = Time.time + _fireRate;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, RecoilReturnSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, startRotation, RecoilReturnSpeed * Time.deltaTime);
    }
    void Shoot()
    {
        currentAmmo--;//currentAmmo =currentAmmo - 1
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
        AmmoText.text = "Ammo:" + currentAmmo.ToString();
        Debug.Log(currentAmmo);
        for (int i = 0; i < bulletsPerShot; i++)
        {
            RaycastHit hit; //defines the ray cast (hitscan)

            //shoot the ray from the cameras position and rotation for the distance in the range  return T/F and the object info of what we hit]
            if (Physics.Raycast(fpsCam.transform.position, GetShootingDirection(), out hit, range))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(fpsCam.transform.position, GetShootingDirection() * hit.distance, Color.yellow, 0.3f);//for hitting
                Target enemy = hit.transform.GetComponent<Target>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            else
            {
                Debug.DrawRay(fpsCam.transform.position, GetShootingDirection() * range, Color.yellow, 0.3f);//for missing
            }
        }
        transform.localPosition -= new Vector3(0, 0, RecoilKickBack);
        transform.localRotation *= Quaternion.Euler(-RecoilKickUp, 0, 0);
    }

    Vector3 GetShootingDirection()
    {
        Vector3 targetPos = fpsCam.transform.position + fpsCam.transform.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccuracyDistance,inaccuracyDistance),
            targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
            );

        Vector3 direction = targetPos - fpsCam.transform.position;
        return direction.normalized;
    }

    bool CanShoot ()
    {
        bool enoughAmmo = currentAmmo > 0;
        return enoughAmmo;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
