using UnityEngine;

public class Beam : MonoBehaviour {

    private Transform _projectorTransform;
    private Collider2D _spotlightCollider;
    private Sprite _sprite;
    private float _thinnestHeight;
    private float _thickestHeight;

    void Start ()
    {
        _projectorTransform = GameObject.Find("Projector").transform;
        _spotlightCollider = GameObject.Find("Spotlight").GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>().sprite;
        _thinnestHeight = _spotlightCollider.bounds.size.y + 1.4f;
        _thickestHeight = _spotlightCollider.bounds.size.x + 2.5f;
    }
	
	void Update ()
    {
        var origin = _projectorTransform.position;
        var destination = _spotlightCollider.bounds.center;
        var difference = destination - origin;
        var desiredLength = difference.magnitude;
        var desiredHeight = (Mathf.Sin(difference.ToAngleInRadians()) * (_thickestHeight - _thinnestHeight)) + _thinnestHeight; // ugly :)

        transform.localScale = GetScaleVector(desiredLength, desiredHeight);
        transform.position = GetPositionBetween(origin, destination);
        transform.rotation = difference.ToEulerRotation();
    }
    
    private Vector3 GetScaleVector(float desiredLength, float desiredHeight)
    {
        // More hacky shit.  Or is this the way Unity intended??  Who the hell knows????
        var scaleX = desiredLength / (_sprite.textureRect.width / 100);
        var scaleY = desiredHeight / (_sprite.textureRect.height / 100);
        return new Vector3(scaleX, scaleY, 1);
    }

    private Vector3 GetPositionBetween(Vector2 vector1, Vector2 vector2)
    {
        return (vector1 + vector2) / 2; // could reset pos.z... but who cares?
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
