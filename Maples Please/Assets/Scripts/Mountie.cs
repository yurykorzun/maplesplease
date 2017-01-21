using UnityEngine;

public class Mountie : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var animator = gameObject.GetComponent<Animator>();

            var vectorFromMountieToMouse = Input.mousePosition - gameObject.transform.position;
            var angle = Vector3.Angle(Vector3.up, vectorFromMountieToMouse);
            if (0f <= angle && angle <= 22.5f)
            {
                animator.SetTrigger("ClickN");
            }
            else if (angle <= 45f)
            {
                animator.SetTrigger("ClickNNE");
            }
            else if (angle <= 67.5f)
            {
                animator.SetTrigger("ClickNE");
            }
            else
            {
                animator.SetTrigger("ClickENE");
            }
        }
    }
}