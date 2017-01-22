using System.Collections;
using UnityEngine;

public class IntroScreenController : MonoBehaviour
{
    public LevelManager LevelManager;
    public AudioSource AudioSource;

    void Start()
    {
        StartCoroutine(DoTheThing());
    }

    private IEnumerator DoTheThing()
    {
        yield return new WaitForSeconds(16);

        AudioSource.enabled = true;
        AudioSource.Play();

        while (AudioSource.isPlaying)
        {
            yield return null;
        }
        
        LevelManager.LoadLevel(@"Playground");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LevelManager.LoadLevel(@"Playground");
        }
    }
}