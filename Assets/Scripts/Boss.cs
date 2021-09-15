using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float RNG;
    public Transform target;
    public Transform homePoint;
    private Vector3 playerPos;
    private Vector3 newPos;
    private bool LastMove = true;
    private Vector3 home;
    private float DistanceToHome;
    public GameObject Projectile;
    public float Velocity = 2000f;
    private bool cooldown = false;
    private bool mineCooldown = true;
    public GameObject Cannon;
    private Transform spawnPoint;
    public GameObject mine;



    private void Awake()
    {
        
        StartCoroutine("RandomMove");
        StartCoroutine("Cooldown");
        home = this.transform.position;
        DistanceToHome = Vector3.Distance(transform.position, transform.position);
        

}



    void Update()
    {
        DistanceToHome = Vector3.Distance(homePoint.position, transform.position);
        

        if(cooldown)
        {
            //Shoot();
        }
      
        if (RNG < 5  && DistanceToHome > 4 && LastMove)
        {
            Mine();
            GoHome();
            
        }
        else if (RNG >= 8)
        {
            Charge();
        }
        else
        {
            MoveTowards();
        }

    }

    IEnumerator RandomMove()
    {
        RNG = Random.Range(1, 10);
        Debug.Log(RNG);
        yield return new WaitForSeconds(1f);
        StartCoroutine("RandomMove");
    }

    private void MoveTowards()
    {
        playerPos = target.transform.position;
        newPos = new Vector3(playerPos.x, 1.443093f, playerPos.z);  
        transform.position = Vector3.MoveTowards(transform.position, newPos, 3f * Time.deltaTime);
        LastMove = true;
       
    }
    private void Charge()
    {
        playerPos = target.transform.position;
        newPos = new Vector3(playerPos.x, 1.443093f, playerPos.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, 14f * Time.deltaTime);
        LastMove = true;

    }

    private void GoHome()
    {
        newPos = new Vector3(home.x, 1.443093f, home.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, 3f * Time.deltaTime);
        LastMove = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PlayerImpact(player);
           // ImpactFeedback();
        }

        LastMove = true;
        RNG = 2;
    }
    /*private void ImpactFeedback()
    {
        //particles
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }
    */

    private void Mine()
    {
        if (mineCooldown)
        {
            Instantiate(mine, Cannon.transform.position, mine.transform.rotation);
            StartCoroutine("MineCooldown");
        }
    }
    private void PlayerImpact(Player player)
    {
        player.DecreaseHealth(1);
    }
    private void Shoot()
    {
        Cannon.transform.LookAt(target);
        GameObject projectile = Instantiate(Projectile, Cannon.transform.position, Cannon.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1500));
        StartCoroutine("Cooldown");

    }
    private IEnumerator Cooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(1f);
        cooldown = true;
    }

    private IEnumerator MineCooldown()
    {
        mineCooldown = false;
        yield return new WaitForSeconds(5f);
        mineCooldown = true;
    }
}
