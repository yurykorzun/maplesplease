using UnityEngine;

public static class VectorExtensions
{
    public static float ToAngleInRadians(this Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x);
    }

    public static float ToAngleInRadians(this Vector3 vector)
    {
        return ((Vector2)vector).ToAngleInRadians();
    }

    public static float ToAngleInDegrees(this Vector2 vector)
    {
        return vector.ToAngleInRadians() * Mathf.Rad2Deg;
    }

    public static float ToAngleInDegrees(this Vector3 vector)
    {
        return vector.ToAngleInRadians() * Mathf.Rad2Deg;
    }

    public static Quaternion ToEulerRotation(this Vector3 vector)
    {
        return Quaternion.Euler(0f, 0f, ((Vector2)vector).ToAngleInDegrees());
    }
}
