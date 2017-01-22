using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyReturn : EnemyDespawner
{
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy"))
		{
			Counter.CountCaptured();

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
