using UnityEngine;

public class BlueAmerican : MonoBehaviour
{
    public float Speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * Speed);
    }
}