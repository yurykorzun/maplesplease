using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {
	public int Total;
	public int NumberRunning;
	public int NumberCaptured;
	public int NumberMissed;

	public HUDManager HudManager;

	public void Awake()
	{
		HudManager.ResetValues();
	}

	public void CountCreated()
	{
		Total++;
		NumberRunning++;

		HudManager.SetTotal(Total);
	}

	public void CountCaptured()
	{
		NumberRunning--;
		NumberCaptured++;

		HudManager.SetCaptured(NumberCaptured);
	}

	public void CountMissed()
	{
		NumberRunning--;
		NumberMissed++;

		HudManager.SetMissed(NumberMissed);
	}
}
