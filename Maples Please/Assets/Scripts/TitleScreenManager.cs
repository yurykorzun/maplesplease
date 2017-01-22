using System;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    private float _timeToWait = 1000;
    private DateTime _startTime;

    public StartButton StartButton;
    public Canvas Canvas;
    public LevelManager LevelManager;
    public AudioSource BGMusic;
    public AudioSource StartNoise;

    void Start()
    {
        _startTime = DateTime.Now;
    }

    void Update()
    {
        if ((DateTime.Now - _startTime).TotalMilliseconds >= _timeToWait)
        {
            var startButton = Instantiate(StartButton, new Vector3(Camera.main.pixelWidth / 2f, Camera.main.pixelHeight / 4f, -1f), new Quaternion());
            startButton.transform.SetParent(Canvas.transform);
            startButton.LevelManager = LevelManager;
            startButton.BGMusic = BGMusic;
            startButton.StartNoise = StartNoise;

            Destroy(this);
        }
    }
}