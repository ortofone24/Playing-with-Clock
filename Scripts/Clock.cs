using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Transform hourTransform, minutesTransform, secondsTransform;

    private const float degreesPerHour = 30f, degreesPerMinute = 6f, degreesPerSecond = 6f;

    private bool continous;

    private Button swapButton;

    private void Awake()
    {
        swapButton = GameObject.FindGameObjectWithTag("swapButton").GetComponent<Button>();
        swapButton.GetComponentInChildren<Text>().text = "Swap to Analog";
    }

    private void Start()
    {
        swapButton.onClick.AddListener(TaskOnClick);
    }
    
    private void Update()
    {
        if (continous == true)
        {
            UpdateContinous();
        }
        else
        {
            UpdateDiscrete();
        }

       
    }

    private void TaskOnClick()
    {
        if (continous) 
        {
            continous = false;
            swapButton.GetComponentInChildren<Text>().text = "Swap to Analog";
        }
        else
        {
            continous = true;
            swapButton.GetComponentInChildren<Text>().text = "Swap to Digital";
        }
    }

    private void UpdateContinous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hourTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }

    private void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;

        hourTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }





}
