using UnityEngine;

public class Mountie : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var animator = gameObject.GetComponent<Animator>();
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition;

            var vectorFromMountieToMouse = mousePosition - gameObject.transform.position;
            var angle = Vector2.Angle(transform.up, vectorFromMountieToMouse);
            
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