using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gunthree : MonoBehaviour
{
    public GameObject nail;
     
    private CharacterInput controls;
    public float shootForce;
    public float upwardForce;
    public float spread;
    [SerializeField] float _fireRate;
    float _timeSinceFired;
    [SerializeField] int maxAmmo;
    int currentAmmo;
    [SerializeField] bool FullAuto = false;
    public Camera fpsCam;
    [SerializeField] Transform muzzle;
    //public bool allowInvoke = true;
    public TextMeshProUGUI AmmoText;
    [SerializeField] float RecoilKickBack = 0.08f;
    [SerializeField] float RecoilKickUp = 6.0f;
    [SerializeField] float RecoilReturnSpeed = 8.0f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    //public GameObject muzzleFlash;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new CharacterInput();
        currentAmmo = maxAmmo;
        AmmoText.text = "Nails:" + currentAmmo.ToString();


    }
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
        if(controls.Player.Shoot.inProgress && FullAuto && Time.time > _timeSinceFired && CanShoot())
        {
            Shoot();
            _timeSinceFired = Time.time + _fireRate;
       }
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, RecoilReturnSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, startRotation, RecoilReturnSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        currentAmmo--;//currentAmmo =currentAmmo - 1
         currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
        AmmoText.text = "Nails:" + currentAmmo.ToString();
        Debug.Log(currentAmmo);
        Vector3 directionWithoutSpread = muzzle.forward;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 directionWithSpread = directionWithoutSpread.normalized + new Vector3(x, y, 0);
        GameObject currentProjectile = Instantiate(nail, muzzle.position, transform.rotation );
        //  if (currentProjectile.TryGetComponent(out Rigidbody rb))
        // {
        //     rb.AddForce(shootForce * muzzle.forward * Time.fixedDeltaTime, ForceMode.Impulse);
        //  }
        //currentProjectile.transform.forward = directionWithoutSpread.normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce * Time.fixedDeltaTime, ForceMode.Impulse);
        currentProjectile.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        transform.localPosition -= new Vector3(0, 0, RecoilKickBack);
        transform.localRotation *= Quaternion.Euler(-RecoilKickUp, 0, 0);
        //if(muzzleFlash != null)
        //{
//Instantiate(muzzleFlash, attackPoint.position, Quaternion.Identity);
       // }

    }
    
    bool CanShoot()
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
