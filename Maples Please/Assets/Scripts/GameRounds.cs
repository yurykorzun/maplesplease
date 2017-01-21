using System;
using System.Collections;
using System.Collections.Generic;
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

	private bool _isFinished;

	private void Awake()
	{
		HUDManager.ResetGameValues();
		HUDManager.SetRound(CurrentRoundNumber);
		HUDAttackManager.ResetGameValues();
	}

	private void Update()
	{
		if (_isFinished) return;

		if (IsGameCompleted())
		{
			Debug.Log("Game Completed");
			_isFinished = true;
			HUDManager.ResetGameValues();
			HUDManager.ShowGameCompleted(Counter.TotalCapturedEnemies, Counter.TotalMissedEnemies);
			HUDAttackManager.ResetGameValues();

			if (GameCompleted != null) GameCompleted.Invoke();

			return;
		}
		if (IsGameLost())
		{
			Debug.Log("Game Lost");

			_isFinished = true;
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

				HUDManager.ResetRoundValues();
				HUDManager.SetRound(CurrentRoundNumber);
				HUDAttackManager.ResetRoundValues();
				if (RoundStarted != null) RoundStarted.Invoke(CurrentRoundNumber);
			}
		}

		var roundedSeconds = Mathf.RoundToInt(_secondsElapsed);
		HUDManager.SetSeconds(roundedSeconds);
		_secondsElapsed += Time.deltaTime;
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
		var isCompleted = _currentRound >= Rounds.Length;

		return isCompleted;
	}
}
