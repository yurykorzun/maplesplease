﻿using System;
using System.Linq;
using UnityEngine;

public class GameRounds : MonoBehaviour {
	public GameRound[] Rounds;
	public EnemyCounter Counter;

	private int _currentRound = 0;
	private float _secondsElapsed = 0f;

	public HUDManager HUDManager;
	public HUDAttackManager HUDAttackManager;

	public Action<int> RoundStarted;
	public Action GameCompleted;
	public Action GameOver;
	public AudioSource WhistleSound;

	private bool _isFinished;

	private void Awake()
	{
		RoundStarted += OnRoundStarted;
		StartNextRound();

		HUDManager.MoneyUSDValue.text = "0";
		HUDManager.MoneyCADValue.text = "0";
	}

	void OnRoundStarted(int round)
	{
		HUDAttackManager.SetPucks(CurrentRound.PucksLimit);
		HUDAttackManager.SetLeafs(CurrentRound.LeafsLimit);
	}

	private void Update()
	{
		if (_isFinished) return;

		if (IsGameCompleted())
		{
			_isFinished = true;
			_secondsElapsed = 0;
			HUDManager.ResetGameValues();
			HUDManager.ShowGameCompleted(Counter.TotalCapturedEnemies, Counter.TotalMissedEnemies);
			HUDAttackManager.ResetGameValues();

			if (GameCompleted != null) GameCompleted.Invoke();

			return;
		}
		if (IsGameLost())
		{
			_isFinished = true;
			_secondsElapsed = 0;
			HUDManager.ResetGameValues();
			HUDAttackManager.ResetGameValues();
			HUDManager.ShowGameOver(Counter.TotalCapturedEnemies, Counter.TotalMissedEnemies);

			if (GameOver != null) GameOver.Invoke();
		}

		if (IsRoundCompleted())
		{
			_secondsElapsed = 0;
			if (!IsGameCompleted())
			{
				_currentRound++;
				StartNextRound();
			}
		}

		var roundedSeconds = Mathf.RoundToInt(_secondsElapsed);
		HUDManager.SetSeconds(roundedSeconds, CurrentRound.LengthInSeconds);

		_secondsElapsed += Time.deltaTime;
	}

	private void StartNextRound() {
		HUDManager.ResetRoundValues();
		HUDManager.ShowWave(CurrentRoundNumber);
		HUDManager.SetRound(CurrentRoundNumber, Rounds.Length);

		HUDAttackManager.ResetRoundValues();
		WhistleSound.Play();
		if (RoundStarted != null) RoundStarted.Invoke(CurrentRoundNumber);
	}

	public float GetSpeed()
	{
		var currentRound = CurrentRound;
		var lastSpeedKey = currentRound.SpeedCurve.keys.Last();

		var timeScale = lastSpeedKey.time;
		var stepValue = currentRound.LengthInSeconds / timeScale;

		var timeScaleValue = _secondsElapsed / stepValue;

		var speed = currentRound.SpeedCurve.Evaluate(timeScaleValue);

		return speed;
	}

	public int GetEnemiesNumber()
	{
		var currentRound = CurrentRound;
		var lastKey = currentRound.EnemyCurve.keys.Last();

		var timeScale = lastKey.time;
		var stepValue = currentRound.LengthInSeconds / timeScale;

		var timeScaleValue = _secondsElapsed / stepValue;

		var speed = currentRound.EnemyCurve.Evaluate(timeScaleValue);

		return Mathf.RoundToInt(speed);
	}

	public float GetDelay()
	{
		var currentRound = CurrentRound;
		var lastKey = currentRound.DelayCurve.keys.Last();

		var timeScale = lastKey.time;
		var stepValue = currentRound.LengthInSeconds / timeScale;

		var timeScaleValue = _secondsElapsed / stepValue;

		var delay = currentRound.DelayCurve.Evaluate(timeScaleValue);

		return delay;
	}

	public float GetWaitSeconds()
	{
		var currentRound = CurrentRound;
		var lastKey = currentRound.WaitCurve.keys.Last();

		var timeScale = lastKey.time;
		var stepValue = currentRound.LengthInSeconds / timeScale;

		var timeScaleValue = _secondsElapsed / stepValue;

		var wait = currentRound.WaitCurve.Evaluate(timeScaleValue);

		return wait;
	}

	public int CurrentRoundNumber
	{
		get
		{
			return _currentRound + 1;
		}
	}

	public GameRound CurrentRound
	{
		get
		{
			var currentRound = Rounds[_currentRound];

			return currentRound;
		}
	}

	private bool IsRoundCompleted()
	{
		var currentRound = CurrentRound;
		var isRoundCompleted = currentRound.LengthInSeconds <= _secondsElapsed;

		return isRoundCompleted;
	}

	private bool IsGameLost()
	{
		var currentRound = CurrentRound;
		var isLost = Counter.RoundMissedEnemies >= currentRound.MaxMissedEnemies;

		return isLost;
	}

	private bool IsGameCompleted()
	{
		var isCompleted = CurrentRoundNumber >= Rounds.Length;

		return isCompleted;
	}
}
