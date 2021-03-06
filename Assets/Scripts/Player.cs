using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    int _treasureCount = 0;
    public GameObject TreasureCount;
    private ScoreUp _scoreUp;
    private HealthUpdate _healthUpdater;
    public bool isInvincible = false;
    public Material _invincibleMat;
    public Material _normalMat;
    public GameObject _tankBody;
    public GameObject _turret;
    public GameObject HealthLevel;
    private bool iFrames = false;
    public Material _damageMat;
    public GameObject Explosion;
    [SerializeField] AudioClip _impactSound;
    public CameraShake cameraShake;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        _scoreUp = TreasureCount.GetComponent<ScoreUp>();
        _healthUpdater = HealthLevel.GetComponent<HealthUpdate>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthUpdater.healthUpdate(_currentHealth);
    }
    
    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        _healthUpdater.healthUpdate(_currentHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (isInvincible == false && iFrames == false)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            _healthUpdater.healthUpdate(_currentHealth);
            StartCoroutine(cameraShake.Shake(1.5f, 0.1f));
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }
    public void Kill()
    {
        gameObject.SetActive(false);
        Instantiate(Explosion, transform.position, transform.rotation);
        AudioHelper.PlayClip2D(_impactSound, 1f);
    }

    public void TreasureCounter()
    {
        _treasureCount++;
        Debug.Log("Treasure Count: " + _treasureCount);
        _scoreUp.TreasureUpdate(_treasureCount);
    }

    public void InvincibleMaterialChange()
    {
        _tankBody.GetComponent<MeshRenderer>().material = _invincibleMat;
        _turret.GetComponent<MeshRenderer>().material = _invincibleMat;
    }
    public void NormalMaterialChange()
    {
        _tankBody.GetComponent<MeshRenderer>().material = _normalMat;
        _turret.GetComponent<MeshRenderer>().material = _normalMat;
    }

    private void DamageMaterialChange()
    {
        _tankBody.GetComponent<MeshRenderer>().material = _damageMat;
        _turret.GetComponent<MeshRenderer>().material = _damageMat;
    }

    private void Update()
    {
        _healthUpdater.healthUpdate(_currentHealth);
    }

}
