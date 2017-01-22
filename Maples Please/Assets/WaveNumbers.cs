using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumbers : MonoBehaviour {
	public Image WaveTitle;
	public Image[] Values;

	public void ShowWave(int number)
	{
		WaveTitle.gameObject.SetActive(true);

		Array.ForEach(Values, x =>
		{
			x.gameObject.SetActive(false);
		});

		Values[number - 1].gameObject.SetActive(true);
	}

	public void HideWave()
	{
		WaveTitle.gameObject.SetActive(false);

		Array.ForEach(Values, x =>
		{
			x.gameObject.SetActive(false);
		});
	}
}
