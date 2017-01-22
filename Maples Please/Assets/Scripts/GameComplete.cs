using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour {

	public Text GameOverLabel;
	public Text GameCompletedLabel;
	public Text TotalCapturedValue;
	public Text TotalMissedValue;

    public GameStats GameStats;

	private void Awake()
	{
		GameOverLabel.gameObject.SetActive(false);
		GameCompletedLabel.gameObject.SetActive(false);

		TotalCapturedValue.text = "0";
		TotalMissedValue.text = "0";
	}

	public void ShowGameOver(int totalCaptured, int totalMissed)
	{
	    GameStats.UpdateGameStats(totalCaptured, totalMissed);

        SceneManager.LoadScene("Defeat");

        //      GameOverLabel.gameObject.SetActive(true);
        //GameCompletedLabel.gameObject.SetActive(false);

        //TotalMissedValue.text = totalMissed.ToString();
        //TotalCapturedValue.text = totalCaptured.ToString();
    }

	public void ShowGameCompleted(int totalCaptured, int totalMissed)
    {
        GameStats.UpdateGameStats(totalCaptured, totalMissed);

        SceneManager.LoadScene("Victory");

  //      GameOverLabel.gameObject.SetActive(false);
		//GameCompletedLabel.gameObject.SetActive(true);

		//TotalMissedValue.text = totalMissed.ToString();
		//TotalCapturedValue.text = totalCaptured.ToString();
	}

	public void StartOver()
	{
		SceneManager.LoadScene("Playground");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
