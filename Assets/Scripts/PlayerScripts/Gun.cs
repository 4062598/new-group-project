using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;
    public float damage = 10f;
    public float range = 100f;//how far we can shoot
    [SerializeField] float _fireRate;
    float _timeSinceFired;
    public Camera fpsCam;

    [SerializeField] GameObject Laser;
    [SerializeField] Transform muzzle;
    [SerializeField] float fadeDuration = 0.3f;



    private void Awake()
    {
        controls = new CharacterInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (controls.Player.Shoot.triggered && Time.time > _timeSinceFired)
        {

            Shoot();
            _timeSinceFired = Time.time + _fireRate;
        }
    }
    void Shoot()
    {
        RaycastHit hit; //defines the ray cast (hitscan)

        //shoot the ray from the cameras position and rotation for the distance in the range  return T/F and the object info of what we hit]
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        { 
            Debug.Log(hit.transform.name);
           // Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * hit.distance, Color.cyan, 0.3f);//for hitting
            Target enemy = hit.transform.GetComponent<Target>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            CreateLaser(hit.point);
        } else
        {
            //Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.cyan, 0.3f);//for missing
            CreateLaser(fpsCam.transform.position + fpsCam.transform.forward * range);
        }
        

    }
   
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void CreateLaser(Vector3 end)
    {
        LineRenderer lr = Instantiate(Laser).GetComponent<LineRenderer>();
        lr.SetPositions(new Vector3[2] { muzzle.position, end });
        StartCoroutine(FadeLaser(lr));
    }

    IEnumerator FadeLaser(LineRenderer lr)
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            lr.startColor = new Color(lr.startColor.r, lr.startColor.g, lr.startColor.b, alpha);
            lr.endColor = new Color(lr.endColor.r, lr.endColor.g, lr.endColor.b, alpha);
            yield return null;

        }
    }
}
