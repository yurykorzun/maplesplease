using UnityEngine;

public class Beam : MonoBehaviour {

    private Transform _projectorTransform;
    private Collider2D _spotlightCollider;
    private Sprite _sprite;
    private float _minHeight;
    private float _maxHeight;

    void Start ()
    {
        _projectorTransform = GameObject.Find("Projector").transform;
        _spotlightCollider = GameObject.Find("Spot").GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>().sprite;

        // Hacky.  But, can't justify spending time to make this fancy :)
        _minHeight = _spotlightCollider.bounds.size.y + 1.4f;
        _maxHeight = _spotlightCollider.bounds.size.x + 2.5f;
    }
	
	void Update ()
    {
        var origin = _projectorTransform.position;
        var destination = _spotlightCollider.bounds.center;
        var difference = destination - origin;
        var desiredLength = difference.magnitude;
        var desiredHeight = (Mathf.Sin(difference.ToAngleInRadians()) * (_maxHeight - _minHeight)) + _minHeight; // leave the ugly math to me :)

        transform.localScale = GetScaleVector(desiredLength, desiredHeight);
        transform.position = GetPositionBetween(origin, destination);
        transform.rotation = difference.ToEulerRotation();
    }
    
    private Vector3 GetScaleVector(float desiredLength, float desiredHeight)
    {
        // Hacky shit.  Or is this the way Unity intended??  Who the hell knows????
        var scaleX = desiredLength / (_sprite.textureRect.width / 100);
        var scaleY = desiredHeight / (_sprite.textureRect.height / 100);
        return new Vector3(scaleX, scaleY, 1);
    }

    private Vector3 GetPositionBetween(Vector2 vector1, Vector2 vector2)
    {
        return (vector1 + vector2) / 2; // Could reset pos.z... but who cares?
    } 
}

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

    public static Quaternion ToEulerRotation(this Vector3 vector)
    {
        return Quaternion.Euler(0f, 0f, ((Vector2)vector).ToAngleInDegrees());
    }
}
