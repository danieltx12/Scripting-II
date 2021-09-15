using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    
    [SerializeField] float _moveSpeed = .25f;
    public float MaxSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }
    [SerializeField] float _turnSpeed = 2f;
    public GameObject Projectile;
    public float Velocity = 200f;
    private bool cooldown = true;
    public GameObject Cannon;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
        if (Input.GetKey(KeyCode.Space) & cooldown)
        {
            Debug.Log("Space Bar Down!!");
            Shoot();
        }
        if(_moveSpeed < 0.1f)
        {
            _moveSpeed = 0.1f;
        }
    }

    public void MoveTank()
    {
        // calculate the move amount
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _moveSpeed;
        // create a vector from amount and direction
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        // apply vector to the rigidbody
        _rb.MovePosition(_rb.position + moveOffset);
        // technically adjusting vector is more accurate! (but more complex)
    }

    public void TurnTank()
    {
        // calculate the turn amount
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        // create a Quaternion from amount and direction (x,y,z)
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // apply quaternion to the rigidbody
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

   private void Shoot()
    {
        GameObject projectile = Instantiate(Projectile, Cannon.transform.position, Cannon.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, Velocity));
        StartCoroutine("Cooldown");
        
    }

    private IEnumerator Cooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(0.5f);
        cooldown = true;
    }

}
