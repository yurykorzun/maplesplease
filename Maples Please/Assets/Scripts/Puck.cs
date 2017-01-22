using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Enemy")
		{
			coll.gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}
}
