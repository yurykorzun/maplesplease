using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Speed;
	public Vector3 Destination;

	// Use this for initialization
	void Update()
	{
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Destination, step);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "EnemyCapture")
		{
			gameObject.SetActive(false);
		}
	}
}
