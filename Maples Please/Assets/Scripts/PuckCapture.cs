using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckCapture : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Puck")
		{
			coll.gameObject.SetActive(false);
		}
	}
}
