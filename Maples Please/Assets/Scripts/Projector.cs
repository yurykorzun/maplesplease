using UnityEngine;

public class Projector : MonoBehaviour
{
    private const int FarRightAngleThreshold = -90;
    private const int RightAngleThreshold = 15;
    private const int CenterAngleThreshold = 60;
    private const int LeftAngleThreshold = 120;

    private Collider2D _spotCollider;
    private Sprite _leftSprite;
    private Sprite _centerSprite;
    private Sprite _rightSprite;
    private Sprite _farRightSprite;

    void Start()
    {
        _spotCollider = GameObject.Find("Spot").GetComponent<Collider2D>();
        _leftSprite = Resources.Load<Sprite>("SpotLeft");
        _centerSprite = Resources.Load<Sprite>("SpotCenter");
        _rightSprite = Resources.Load<Sprite>("SpotRight");
        _farRightSprite = Resources.Load<Sprite>("SpotFarRight");
    }

    void Update()
    {
        var targetVector = _spotCollider.bounds.center - transform.position;
        var angle = targetVector.ToAngleInDegrees();

        GetComponent<SpriteRenderer>().sprite =
            angle >= FarRightAngleThreshold && angle < RightAngleThreshold ? _farRightSprite :
            angle >= RightAngleThreshold && angle < CenterAngleThreshold ? _rightSprite :
            angle >= CenterAngleThreshold && angle < LeftAngleThreshold ? _centerSprite :
            _leftSprite;
    }
}
