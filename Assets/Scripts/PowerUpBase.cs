using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);
    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;
    [SerializeField] float _movementSpeed = 1;
    [SerializeField] float powerupDuration = 1;
    protected Rigidbody _rb;
    Collider _collider;
    Renderer _renderer;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<MeshRenderer>();
    }
    protected virtual void Movement(Rigidbody rb)
    {
        // calaculate rotation
        Quaternion turnOffset = Quaternion.Euler(_movementSpeed, _movementSpeed, _movementSpeed);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }
    private void FixedUpdate()
    {
        Movement(_rb);
    }

    protected  void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            //spawn particles & sfx because we need to disable object
            // Feedback();

            _collider.enabled = !_collider.enabled;
            _renderer.enabled = !_renderer.enabled;

            StartCoroutine(PowerupWait(player));   
            
        }
    }

    IEnumerator PowerupWait(Player player)
    {
        yield return new WaitForSeconds(powerupDuration);
        PowerDown(player);
        Debug.Log("DONE!!!!");
        gameObject.SetActive(false);
    }
}
