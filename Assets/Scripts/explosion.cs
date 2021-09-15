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
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1);

        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
