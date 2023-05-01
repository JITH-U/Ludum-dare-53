using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private int minutes = 1;

    // Private Variables
    private float timer;
    [HideInInspector] private int min, sec;
    [HideInInspector] private string timerStr;

    private void Start()
    {
        timer = minutes * 60;
    }

    private void Update()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0) timer = 0;
        UpdateTimerDisplay();
    }

    // Private Methods
    private void UpdateTimerDisplay()
    {
        // calculate minute and seconds
        min = Mathf.FloorToInt(timer / 60);
        sec = Mathf.FloorToInt(timer % 60);

        // update UI
        timerStr = string.Format("{00:00}:{1:00}", min, sec);
        timerText.text = (min >= 10) ? timerStr : timerStr.Substring(1, timerStr.Length - 1);
    }
}
