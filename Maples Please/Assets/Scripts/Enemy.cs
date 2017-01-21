using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Range(1, 4)]
	public float WaitSeconds;
	public float Speed;
	public Vector3 Origin;
	public Vector3 Destination;
	public Vector3 Return;
	
	private bool _isInSpotlight;
	private float _secondsWaiting;
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

		if (_isInSpotlight)
		{
			_secondsWaiting += Time.deltaTime;
			if(_secondsWaiting >= WaitSeconds)
			{
				_enemyCounter.CountCaptured();
				Destination = Return;
			}
		}
		else
		{
			_secondsWaiting = 0f;
		}
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

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains(_spotlightName))
		{
			Speed /= _speedFactor;

			_isInSpotlight = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains(_spotlightName))
		{
			_isInSpotlight = false;
			Speed *= _speedFactor;
		}
	}
}
