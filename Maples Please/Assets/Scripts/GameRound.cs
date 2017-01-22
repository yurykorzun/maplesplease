using UnityEngine;

public class GameRound : MonoBehaviour
{
	public AnimationCurve SpeedCurve;
	public AnimationCurve EnemyCurve;
	public AnimationCurve DelayCurve;
	public AnimationCurve WaitCurve;

	public int LengthInSeconds;
	public int MaxMissedEnemies;
	public int PucksLimit;
    public int LeafsLimit;
}

