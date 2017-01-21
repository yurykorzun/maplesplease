using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Speed;
	public Vector3 Destination;
	private EnemyCounter _enemyCounter;

	private void Awake()
	{
		_enemyCounter = FindObjectOfType<EnemyCounter>();
	}

	// Use this for initialization
	void Update()
	{
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Destination, step);
	}

	void OnMouseDown()
	{
		_enemyCounter.CountCaptured();
		gameObject.SetActive(false);
	}
}
