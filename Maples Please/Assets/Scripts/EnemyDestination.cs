﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : EnemyDespawner
{
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy"))
		{
			Counter.CountMissed();

			coll.gameObject.transform.localScale = new Vector3
			{
				x = 1f,
				y = 1f,
				z = coll.gameObject.transform.localScale.z
			};
			coll.gameObject.SetActive(false);
		}
	}
}
