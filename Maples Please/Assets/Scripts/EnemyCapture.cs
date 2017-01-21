using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapture : MonoBehaviour {

	public EnemyCounter Counter;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy"))
		{
			Counter.CountMissed();

			coll.gameObject.SetActive(false);
		}
	}
}
