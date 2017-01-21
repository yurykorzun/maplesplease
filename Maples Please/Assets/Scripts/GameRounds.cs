using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRounds : MonoBehaviour {
	public GameRound[] Rounds;
	private int _currentRound = 0;
	private float _secondsElapsed = 0f;

	public HUDManager HUDManager;

	private void Awake()
	{
		HUDManager.SetRound(CurrentRoundNumber);
	}

	private void Update()
	{
		if (IsRoundCompleted())
		{
			_secondsElapsed = 0;
			if (!IsGameCompleted())
			{
				_currentRound++;

				HUDManager.SetRound(CurrentRoundNumber);
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

	private bool IsRoundCompleted()
	{
		var currentRound = Rounds[_currentRound];

		var isRoundCompleted = currentRound.LengthInSeconds <= _secondsElapsed;

		return isRoundCompleted;
	}

	private bool IsGameCompleted()
	{
		var isCompleted = _currentRound >= Rounds.Length;

		return isCompleted;
	}
}
