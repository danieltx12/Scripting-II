using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    public GameObject Explosion;
    

    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        
    }
    
}
