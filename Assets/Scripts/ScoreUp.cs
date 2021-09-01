using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUp : MonoBehaviour

     
{
    // Start is called before the first frame update
    void Start()
    {
        Text score;
        score = GetComponent<Text>();
        score.text = "0";

    }

    public void TreasureUpdate(int _treasureCount)
    {
        Text score;
        score = GetComponent<Text>();
        score.text = _treasureCount.ToString();
    }


}
