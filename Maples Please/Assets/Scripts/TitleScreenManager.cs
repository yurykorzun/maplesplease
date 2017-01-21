using System;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    private float _timeToWait = 1000;
    private DateTime _startTime;

    public GameObject StartButton;
    public Canvas Canvas;
    public LevelManager LevelManager;

    void Start()
    {
        _startTime = DateTime.Now;
    }

    void Update()
    {
        if ((DateTime.Now - _startTime).TotalMilliseconds >= _timeToWait)
        {
            var startButton = Instantiate(StartButton, new Vector3(400f, 150f, -1f), new Quaternion());
            startButton.transform.SetParent(Canvas.transform);
            startButton.GetComponent<Button>().onClick.AddListener(delegate() { LevelManager.LoadLevel("Playground"); });

            Destroy(this);
        }
    }
}