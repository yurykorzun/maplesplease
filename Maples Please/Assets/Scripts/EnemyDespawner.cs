using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class EnemyDespawner : MonoBehaviour
{
	public EnemyCounter Counter;
	private BoxCollider2D _boxCollider;

	public void Awake()
	{
		_boxCollider = GetComponent<BoxCollider2D>();
	}

	public Vector3 GetRandomDestination()
	{
		var colliderXSize = _boxCollider.size.x;
		var positionX = transform.position.x;
		var halfXSize = colliderXSize / 2;

		var randomXPosition = UnityEngine.Random.Range(positionX - halfXSize, positionX + halfXSize);

		return new Vector3(randomXPosition, transform.position.y);
	}
}

