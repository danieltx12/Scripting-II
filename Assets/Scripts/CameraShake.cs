using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
    public Image redScreen;
    Color tempColor;
    bool isRed = false;

    private void Awake()
    {
        Color tempColor = redScreen.color;
        tempColor.a = 0f;
        redScreen.color = tempColor;
    }
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        
        while (elapsed < duration)
        {
            
            
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            if (!isRed)
            {
                tempColor.a = 0.5f;
                tempColor.r = 255f;
                redScreen.color = tempColor;
                isRed = true;
            }
            else
            {
                tempColor.r = 255f;
                tempColor.a = 0f;
                redScreen.color = tempColor;
                isRed = false;
            }


            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        tempColor.r = 255f;
        tempColor.a = 0f;
        redScreen.color = tempColor;
        isRed = false;
    }
}
