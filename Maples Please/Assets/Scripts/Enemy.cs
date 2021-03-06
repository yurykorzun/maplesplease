﻿using UnityEngine;

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
	private string _spotlightName = "Spot";

	private void Awake()
	{
		_enemyCounter = FindObjectOfType<EnemyCounter>();
    }

    void Start()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Destination, step);




        //var vector = Destination - Origin;
        //if (vector.ToAngleInDegrees() <= 15)
        //{
        //    gameObject.GetComponent<Animator>().SendMessage(@"GoForward");
        //}
        //else if (Origin.x < Destination.x)
        //{
        //    gameObject.GetComponent<Animator>().SendMessage(@"GoRight");
        //}
        //else
        //{
        //    gameObject.GetComponent<Animator>().SendMessage(@"GoLeft");
        //}
    }

    private void OnEnable()
    {
    }

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
				Destination = Return;
				_secondsWaiting = 0f;
				_isInSpotlight = false;
				_enemyCounter.AddUSD(1);
			    gameObject.GetComponent<Animator>().SetTrigger(@"GoBack");
			}
		}
		else
		{
			_secondsWaiting = 0f;
		}
	}

	public void AdjustScale() {

		float distance = transform.position.y - Origin.y;
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
