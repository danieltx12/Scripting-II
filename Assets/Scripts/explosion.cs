using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine("Destroy");
    }
    private void OnParticleCollision(GameObject other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        Player player = other.gameObject.GetComponent<Player>();
        mine Mine = other.gameObject.GetComponent<mine>();
        if (enemy != null)
        {
            Destroy(other.gameObject);

        }
        else if (player != null)
        {
            player.DecreaseHealth(1);

        }
        else if (Mine != null)
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
