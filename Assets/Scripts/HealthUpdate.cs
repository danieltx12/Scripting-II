using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour
{
    void Start()
    {
        Text score;
        score = GetComponent<Text>();
        score.text = "3";

    }

    public void healthUpdate(int _currentHealth)
    {
        Text health;
        health = GetComponent<Text>();
        health.text = _currentHealth.ToString();
    }


}
