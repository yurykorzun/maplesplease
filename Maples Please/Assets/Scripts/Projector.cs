using UnityEngine;

public class Projector : MonoBehaviour {

    private Collider2D _spotCollider;
    private Sprite _leftSprite;
    private Sprite _centerSprite;
    private Sprite _rightSprite;

    void Start ()
    {
        _spotCollider = GameObject.Find("Spot").GetComponent<Collider2D>();
        _leftSprite = Resources.Load<Sprite>("SpotLeft");
        _centerSprite = Resources.Load<Sprite>("SpotCenter");
        _rightSprite = Resources.Load<Sprite>("SpotRight");
    }
	
    void Update ()
    {
        var targetVector = _spotCollider.bounds.center - transform.position;
        var angle = targetVector.ToAngleInDegrees();

        GetComponent<SpriteRenderer>().sprite = angle >= -90 && angle < 60 ? _rightSprite : 
                                                angle >= 50 && angle < 120 ? _centerSprite : 
                                                _leftSprite;
    }
}
