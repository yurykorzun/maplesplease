using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static int TotalCapturedValue;
    public static int TotalMissedValue;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateGameStats(int totalCapturedValue, int totalMissedValue)
    {
        TotalCapturedValue = totalCapturedValue;
        TotalMissedValue = totalMissedValue;
    }
}