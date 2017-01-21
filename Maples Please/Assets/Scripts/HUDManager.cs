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

	private float _exchangeRate = 0;

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

	public void SetExchangeRate(float factor) {

		// update the exchange rate
		_exchangeRate += (_exchangeRate *= factor);

		// get the current USD labe as a float
		var currentUSD = float.Parse(MoneyUSDValue.text);

		UpdateMoney(currentUSD);
	}

	public void UpdateMoney(float currentUSD) {

		// update the USD label
		MoneyUSDValue.text = currentUSD.ToString();

		if (currentUSD > 0) {

			// if local rate is zero
			if (_exchangeRate == 0) {

				// get from settings
				_exchangeRate = GameSettings.CADExchangeRate;
			}

			// if rate is still zero
			if (_exchangeRate == 0) {

				// hard-code
				_exchangeRate = 1.3F;
			}

			// update the CAD value
			MoneyCADValue.text = (currentUSD * _exchangeRate).ToString ("N");
		}
	}
}
