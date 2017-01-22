using UnityEngine;

public class BulletCapture : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Puck" || coll.gameObject.name == "Leaf") // todo - must be a better way?
		{
			coll.gameObject.SetActive(false);
		}
	}
}
