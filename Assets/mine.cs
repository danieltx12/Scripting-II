using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    public GameObject Explosion;
    

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        projectile Projectile = other.gameObject.GetComponent<projectile>();
        if (player != null)
        {
            Instantiate(Explosion, player.transform.position, player.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }

        
    }
    
}
