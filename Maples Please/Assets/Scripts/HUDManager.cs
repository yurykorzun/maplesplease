using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	public Text TotalValue;
	public Text CapturedValue;
	public Text MissedValue;
	public Text SecondsValue;
	public Text RoundValue;
	public Text RoundWaveTitle;
	public Text MoneyUSDValue;
	public Text MoneyCADValue;

	public GameComplete GameComplete;

	public void SetCaptured(int number)
	{
		CapturedValue.text = number.ToString();
	}

	public void SetMissed(int number, int allowedMissed)
	{
		MissedValue.text = string.Format("{0}/{1}", number, allowedMissed);
	}

	public void SetTotal(int number)
	{
		TotalValue.text = number.ToString();
	}

	public void ShowGameOver(int totalCaptured, int totalMissed)
	{
		GameComplete.gameObject.SetActive(true);
		GameComplete.ShowGameOver(totalCaptured, totalMissed);
	}

	public void ShowGameCompleted(int totalCaptured, int totalMissed)
	{
		GameComplete.gameObject.SetActive(true);
		GameComplete.ShowGameCompleted(totalCaptured, totalMissed);
	}

	public void ResetGameValues()
	{
		CapturedValue.text = "0";
		MissedValue.text = "0";
		TotalValue.text = "0";
		RoundValue.text = "0";
		SecondsValue.text = "0";
		MoneyUSDValue.text = "100";
		MoneyCADValue.text = "0";
	}

	public void ResetRoundValues()
	{
		CapturedValue.text = "0";
		MissedValue.text = "0";
		TotalValue.text = "0";
		SecondsValue.text = "0";
	}

	public void SetRound(int roundNumber, int totalRounds)
	{
		RoundValue.text = string.Format("{0}/{1}", roundNumber, totalRounds);
		RoundWaveTitle.text = string.Format("Wave {0}", roundNumber);
	}

	public void SetSeconds(int seconds, int totalSeconds)
	{
		SecondsValue.text = string.Format("{0}/{1}", seconds, totalSeconds);
	}

	public void UpdateCADExchangeRateValue() {

		// get the exhange rate from settings
		var exchangeRate = GameSettings.CADExchangeRate;
		if (exchangeRate == 0) {
			exchangeRate = 1.3F;
		}

		// get the USD
		var rateUSD = float.Parse(MoneyUSDValue.text);

		// set the CAD
		MoneyCADValue.text = (rateUSD * exchangeRate).ToString("N");
	}
}
