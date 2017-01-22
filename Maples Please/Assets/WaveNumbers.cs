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

		StartCoroutine(UpdateScale());
	}

	public IEnumerator UpdateScale()
	{
		transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f, 1f);

		yield return new WaitForSeconds(0.2f);

		StartCoroutine(UpdateScale());
	}

	public void HideWave()
	{
		StopAllCoroutines();
		transform.localScale = new Vector3(1f, 1f, 1f);
		WaveTitle.gameObject.SetActive(false);

		Array.ForEach(Values, x =>
		{
			x.gameObject.SetActive(false);
		});
	}
}
