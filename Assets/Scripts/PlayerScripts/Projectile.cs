using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    Rigidbody m_Rigidbody;
    
    void Start()
    {
        Invoke(nameof(Impact), 20f);
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Projectile")) return;
        if(other.TryGetComponent(out Target target))
        {
           
                target.TakeDamage(damage);
            Destroy(gameObject);
        }
        m_Rigidbody.isKinematic = true;

        Invoke(nameof(Impact), 5f);

    }
    public void Impact()
    {

        Destroy(gameObject);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
//tipity topity