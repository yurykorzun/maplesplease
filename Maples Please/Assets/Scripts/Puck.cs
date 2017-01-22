using UnityEngine;

public class Puck : Bullet
{
    public override Bullet CloneInstance()
    {
        var instance = Instantiate(this, gameObject.transform.position, Quaternion.identity);
        instance.name = "Puck";
        return instance;
    }

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Enemy")
		{
			coll.gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}
}
