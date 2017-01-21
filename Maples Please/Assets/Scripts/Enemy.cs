using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Speed;
	public Vector3 Origin;
	public Vector3 Destination;
	public Vector3 EnemyPosition;

	private EnemyCounter _enemyCounter;
	private float _speedFactor = 2;
	private float _scaleFactor = .1F;
	private string _spotlightName = "Spotlight";

	private void Awake()
	{
		_enemyCounter = FindObjectOfType<EnemyCounter>();
	}

	// Use this for initialization
	void Update()
	{
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Destination, step);

		// scale
		AdjustScale();
	}

	public void AdjustScale() {

		float distance = Vector3.Distance(transform.position, Origin);
		float scale = (distance * _scaleFactor);

		// update the scale of the enemy based on their position toward the destination
		transform.localScale = new Vector3 {
			x = scale, 
			y = scale, 
			z = transform.localScale.z 
		};
	}

	void OnMouseDown()
	{
		_enemyCounter.CountCaptured();
		gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains(_spotlightName))
		{
			Speed /= _speedFactor;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains(_spotlightName))
		{
			Speed *= _speedFactor;
		}
	}
}
