using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour {
	public int Total;
	public int NumberRunning;
	public int NumberCaptured;
	public int NumberMissed;

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
	}

	public void CountCaptured()
	{
		NumberCaptured++;
	}

	public void CountMissed()
	{
		NumberRunning--;
		NumberMissed++;
	}
}
