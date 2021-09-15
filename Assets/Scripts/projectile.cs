using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject Explosion;
    private void Awake()
    {
        StartCoroutine("Delete");
    }

    private void OnCollisionEnter(Collision other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        Player player = other.gameObject.GetComponent<Player>();
        Boss boss = other.gameObject.GetComponent<Boss>();
        if (enemy != null)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(Explosion, other.transform.position, other.gameObject.transform.rotation);
        }
        else if (player != null)
        {
            player.DecreaseHealth(1);
            Instantiate(Explosion, other.transform.position, other.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(Explosion, transform.position, other.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
      
    }

   private IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    private void Frag()
    {
       
    }
}
