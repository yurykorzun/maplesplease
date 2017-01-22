using System.Collections;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public AudioSource BGMusic;
    public AudioSource StartNoise;
    public LevelManager LevelManager;
    
    public void ClickStart()
    {
        StartCoroutine(DoStart());
    }

    private IEnumerator DoStart()
    {
        BGMusic.Stop();
        StartNoise.enabled = true;
        StartNoise.Play();
        yield return new WaitForSeconds(1);
        LevelManager.LoadLevel("IntroStory");
    }
}