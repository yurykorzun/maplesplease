﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {
	public GameRounds Rounds;
	public HUDManager HudManager;

	public int TotalEnemies;
	public int TotalCapturedEnemies;
	public int TotalMissedEnemies;

	public int RoundTotalEnemies;
	public int RoundRunningEnemies;
	public int RoundCapturedEnemies;
	public int RoundMissedEnemies;

	public void Awake()
	{
		Rounds.RoundStarted += RoundStarted;
	}

	public void Start()
	{
		HudManager.SetMissed(RoundMissedEnemies, Rounds.CurrentRound.MaxMissedEnemies);
	}

	public void RoundStarted(int round)
	{
		RoundTotalEnemies = 0;
		RoundRunningEnemies = 0;
		RoundCapturedEnemies = 0;
		RoundMissedEnemies = 0;
	}

	public void CountCreated()
	{
		TotalEnemies++;
		RoundRunningEnemies++;
		RoundTotalEnemies++;

		HudManager.SetTotal(RoundTotalEnemies);
	}

	public void CountCaptured()
	{
		RoundRunningEnemies--;
		RoundCapturedEnemies++;
		TotalCapturedEnemies++;

		HudManager.SetCaptured(RoundCapturedEnemies);
	}

	public void CountMissed()
	{
		RoundRunningEnemies--;
		RoundMissedEnemies++;
		TotalMissedEnemies++;

		HudManager.SetMissed(RoundMissedEnemies, Rounds.CurrentRound.MaxMissedEnemies);
	}
}
