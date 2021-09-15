using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject Explosion;
    [SerializeField] AudioClip _impactSound;
    private void Awake()
    {
        StartCoroutine("Delete");
    }

    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null) 
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
            damageable.TakeDamage(1);
            Instantiate(Explosion, other.transform.position, other.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            
            Instantiate(Explosion, other.transform.position, other.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
        
    }

   private IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Explosion, transform.position, transform.rotation);
        AudioHelper.PlayClip2D(_impactSound, 1f);
        Destroy(this.gameObject);
    }

    private void Frag()
    {
       
    }
}
