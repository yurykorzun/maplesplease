using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour {

	public EnemyCounter Counter;
	private BoxCollider2D _boxCollider;

	public void Start()
	{
		_boxCollider = GetComponent<BoxCollider2D>();
	}

	public Vector3 GetRandomDestination()
	{
		var colliderXSize = _boxCollider.size.x;
		var positionX = transform.position.x;
		var halfXSize = colliderXSize / 2;

		var randomXPosition = Random.Range(positionX - halfXSize, positionX + halfXSize);

		return new Vector3(randomXPosition, transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy"))
		{
			Counter.CountMissed();

			coll.gameObject.SetActive(false);
		}
	}
}
