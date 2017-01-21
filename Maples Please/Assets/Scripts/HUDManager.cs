using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	public Text TotalValue;
	public Text CapturedValue;
	public Text MissedValue;
	public Text SecondsValue;
	public Text RoundValue;

	public void SetCaptured(int number)
	{
		CapturedValue.text = number.ToString();
	}

	public void SetMissed(int number)
	{
		MissedValue.text = number.ToString();
	}

	public void SetTotal(int number)
	{
		TotalValue.text = number.ToString();
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

	public void SetRound(int seconds)
	{
		RoundValue.text = seconds.ToString();
	}

	public void SetSeconds(int seconds)
	{
		SecondsValue.text = seconds.ToString();
	}
}
