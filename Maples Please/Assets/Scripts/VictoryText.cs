using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Total Missed: " + GameStats.TotalMissedValue + "\r\nTotal Captured: " + GameStats.TotalCapturedValue;
    }
    
    void Update()
    {
    }
}