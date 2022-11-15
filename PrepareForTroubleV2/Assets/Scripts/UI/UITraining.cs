using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITraining : MonoBehaviour
{
    [Header("Timer")]
    public Slider timerBar;
    public float maxTime = 30f;
    float timeLeft;
    public TextMeshProUGUI timer;

        
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void SetTimer(float timeToSet)
    {
        timeLeft = timeToSet;
        maxTime = timeToSet;
    }

    public void UpdateTimer()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            int timerLeftInt = Mathf.FloorToInt(timeLeft);
            timer.text = timerLeftInt.ToString();
            timerBar.value = timeLeft / maxTime;

        }
        else
        {

        }
    }
}
