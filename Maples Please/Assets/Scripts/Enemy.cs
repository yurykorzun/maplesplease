using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * Speed);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "EnemyCapture")
		{
			gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
