using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyReturn : EnemyDespawner
{
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Enemy")
		{
			Counter.CountCaptured();

			coll.gameObject.SetActive(false);
		}
	}
}
