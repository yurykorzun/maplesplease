using System;
using UnityEngine;

public class Mountie : MonoBehaviour
{
    private DateTime _timeOfLastAttack = DateTime.MinValue;

    public int AttackPower;
    public float FireRate;

    public Rigidbody2D Puck;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (DateTime.Now - _timeOfLastAttack).TotalMilliseconds >= FireRate)
        {
            _timeOfLastAttack = DateTime.Now;
            
            var animator = gameObject.GetComponent<Animator>();
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition;

            var vectorFromMountieToMouse = mousePosition - gameObject.transform.position;
            var angle = Vector2.Angle(transform.up, vectorFromMountieToMouse);
            
            var puck = Instantiate(Puck, gameObject.transform.position, new Quaternion());
            puck.velocity = new Vector2(vectorFromMountieToMouse.x, vectorFromMountieToMouse.y).normalized * AttackPower;

            if (mousePosition.x < gameObject.transform.position.x)
            {
                if (angle <= 22.5f)
                {
                    animator.SetTrigger("ClickNNW");
                }
                else if (angle <= 45f)
                {
                    animator.SetTrigger("ClickNW");
                }
                else if (angle <= 67.5f)
                {
                    animator.SetTrigger("ClickWNW");
                }
                else
                {
                    animator.SetTrigger("ClickW");
                }
            }
            else
            {
                if (angle <= 22.5f)
                {
                    animator.SetTrigger("ClickNNE");
                }
                else if (angle <= 45f)
                {
                    animator.SetTrigger("ClickNE");
                }
                else if (angle <= 67.5f)
                {
                    animator.SetTrigger("ClickENE");
                }
                else
                {
                    animator.SetTrigger("ClickE");
                }
            }
        }
    }
}