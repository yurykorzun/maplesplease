using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {
	public int Total;
	public int NumberRunning;
	public int NumberCaptured;
	public int NumberMissed;

	public Text TotalValue;
	public Text CapturedValue;
	public Text MissedValue;

	public void Awake()
	{
		TotalValue.text = "0";
		CapturedValue.text = "0";
		MissedValue.text = "0";
	}

	public void ResetCounter()
	{
		Total = 0;
		NumberCaptured = 0;
		NumberRunning = 0;
		NumberMissed = 0;
	}

	public void CountCreated()
	{
		Total++;
		NumberRunning++;

		TotalValue.text = Total.ToString();
	}

	public void CountCaptured()
	{
		NumberRunning--;
		NumberCaptured++;
		CapturedValue.text = NumberCaptured.ToString();
	}

	public void CountMissed()
	{
		NumberRunning--;
		NumberMissed++;

		MissedValue.text = NumberMissed.ToString();
	}
}
