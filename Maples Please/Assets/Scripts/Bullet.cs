using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public int AttackPower;

    public abstract Bullet CloneInstance();

    public void Fire(Vector3 position, Vector2 direction)
    {
        gameObject.SetActive(true);
        transform.position = position;
        GetComponent<Rigidbody2D>().velocity = direction.normalized * AttackPower;
    }
}