using UnityEngine;

public class Leaf : Bullet
{
    public override Bullet CloneInstance()
    {
        var instance = Instantiate(this, gameObject.transform.position, Quaternion.identity);
        instance.name = "Leaf";
        return instance;
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
