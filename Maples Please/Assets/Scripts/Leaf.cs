using UnityEngine;

public class Leaf : Bullet
{
    public float RotationSpeed = 1;

    public override Bullet CloneInstance()
    {
        var instance = Instantiate(this, gameObject.transform.position, Quaternion.identity);
        instance.name = "Leaf";
        return instance;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, RotationSpeed));
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Enemy")
        {
            coll.gameObject.SetActive(false);

            // todo - fancy syrup explosion here.
        }
    }
}
