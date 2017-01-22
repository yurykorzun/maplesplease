using UnityEngine;

public class Beam : MonoBehaviour {

    private Transform _projectorTransform;
    private Collider2D _spotCollider;
    private Sprite _sprite;
    private float _minHeight;
    private float _maxHeight;

    void Start ()
    {
        _projectorTransform = GameObject.Find("Projector").transform;
        _spotCollider = GameObject.Find("Spot").GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>().sprite;

        // Hacky.  But, can't justify spending time to make this fancy :)
        _minHeight = _spotCollider.bounds.size.y + 1.4f;
        _maxHeight = _spotCollider.bounds.size.x + 2.5f;
    }
	
	void Update ()
    {
        var origin = _projectorTransform.position;
        var destination = _spotCollider.bounds.center;
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
