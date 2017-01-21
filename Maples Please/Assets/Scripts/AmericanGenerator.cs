using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmericanGenerator : MonoBehaviour
{
    private DateTime _timeOfLastAmerican = DateTime.MinValue;
    private float _timeBetweenAmericans = -1;

    public BlueAmerican BlueAmerican;
    
    void Update()
    {
        if (_timeBetweenAmericans <= (DateTime.Now - _timeOfLastAmerican).TotalSeconds)
        {
            GenerateAmerican();
        }
    }

    private void GenerateAmerican()
    {
        _timeOfLastAmerican = DateTime.Now;
        _timeBetweenAmericans = Random.Range(0f, 2f);
        
        var speed = Random.Range(1, 5);
        var position = Random.Range(-5.5f, 5.5f);

        var blueAmerican = Instantiate(BlueAmerican, new Vector3(position, 4f, 0f), new Quaternion());
        blueAmerican.Speed = speed;
    }
}