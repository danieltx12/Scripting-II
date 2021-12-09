using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour
{
    [SerializeField] Image health;
    
    void Start()
    {
        health = GetComponent<Image>();

    }


    public void healthUpdate(int _currentHealth)
    {
        
        health.rectTransform.sizeDelta = new Vector2((_currentHealth * 100), 20);
    }


}
