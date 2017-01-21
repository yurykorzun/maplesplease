using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

	public static float CADExchangeRate = 0;

	private static string _exchangeRateUrl = "http://api.fixer.io/latest?base=USD&symbols=USD,CAD";

	// Use this for initialization
	void Start () {

		// keep alive
		DontDestroyOnLoad (gameObject);

		// set the exchange rate
		SetCADExchangeRate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FinishDownload(string url) {
		var wwwData = new WWW (_exchangeRateUrl);
		while (!wwwData.isDone) {
			yield return wwwData;
		}
		var jsonData = JSON.Parse(wwwData.text);
		var cadValue = float.Parse(jsonData["rates"][0]);

		// set the property
		CADExchangeRate = cadValue;
	}

	public void SetCADExchangeRate() {
		StartCoroutine(FinishDownload(_exchangeRateUrl));
	}
}
