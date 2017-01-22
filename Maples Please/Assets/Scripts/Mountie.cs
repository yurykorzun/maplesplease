using System;
using System.Linq;
using UnityEngine;

public class Mountie : MonoBehaviour
{
    private Animator _animator;
    private BulletGenerator _puckGenerator;
    private BulletGenerator _leafGenerator;
	private DateTime _timeOfLastAttack = DateTime.MinValue;
    public float FireDelay;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _puckGenerator = gameObject.GetComponentsInChildren<BulletGenerator>().Single(x => x.name == "PuckGenerator");
        _leafGenerator = gameObject.GetComponentsInChildren<BulletGenerator>().Single(x => x.name == "LeafGenerator");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (DateTime.Now - _timeOfLastAttack).TotalMilliseconds >= FireDelay)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var vectorFromMountieToMouse = mousePosition - gameObject.transform.position;

            if (_puckGenerator.GenerateBullet(gameObject.transform.position, vectorFromMountieToMouse))
            {             
                _timeOfLastAttack = DateTime.Now;
                        
                var angle = Vector2.Angle(transform.up, vectorFromMountieToMouse);
            
                if (mousePosition.x < gameObject.transform.position.x)
                {
                    if (angle <= 22.5f)
                    {
                        _animator.SetTrigger("ClickNNW");
                    }
                    else if (angle <= 45f)
                    {
                        _animator.SetTrigger("ClickNW");
                    }
                    else if (angle <= 67.5f)
                    {
                        _animator.SetTrigger("ClickWNW");
                    }
                    else
                    {
                        _animator.SetTrigger("ClickW");
                    }
                }
                else
                {
                    if (angle <= 22.5f)
                    {
                        _animator.SetTrigger("ClickNNE");
                    }
                    else if (angle <= 45f)
                    {
                        _animator.SetTrigger("ClickNE");
                    }
                    else if (angle <= 67.5f)
                    {
                        _animator.SetTrigger("ClickENE");
                    }
                    else
                    {
                        _animator.SetTrigger("ClickE");
                    }
                }
            }
        }
    }
}