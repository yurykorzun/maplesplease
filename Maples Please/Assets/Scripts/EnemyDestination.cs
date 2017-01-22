﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : EnemyDespawner
{
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Enemy")
		{
			Counter.CountMissed();

			coll.gameObject.SetActive(false);
		}
	}
}
