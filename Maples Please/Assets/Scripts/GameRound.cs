using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameRound : MonoBehaviour
{
	public AnimationCurve SpeedCurve;
	public AnimationCurve EnemyCurve;
	public AnimationCurve DelayCurve;

	public int LengthInSeconds;
	public int MaxMissedEnemies;
}

