using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameRounds Rounds;
	public Enemy EnemyPrefab;
	public EnemyDestination Destination;
	public EnemyCounter Counter;

	private List<Enemy> _enemyPool = new List<Enemy>();
	private BoxCollider2D _boxCollider;

	private bool _isCompleted;

	void Start()
	{
		Rounds.GameCompleted += GameWasCompleted;
		Rounds.GameOver += GameWasCompleted;

		_boxCollider = GetComponent<BoxCollider2D>();
		StartCoroutine(GenerateEnemies());
	}


	void Update()
	{
		if (_isCompleted) StopAllCoroutines();
	}

	private void GameWasCompleted()
	{
		_isCompleted = true;
		ResetEnemies();
	}

	private void ResetEnemies()
	{
		foreach (var enemy in _enemyPool)
		{
			enemy.transform.position = transform.position;
			enemy.gameObject.SetActive(false);
		}
	}

	private IEnumerator GenerateEnemies()
	{

		var numberOfEmenies = Random.Range(1, 5);
		var colliderXSize = _boxCollider.size.x;
		var generatorXPosition = transform.position.x;
		var xHalf = colliderXSize / 2;

		for (var i = 0; i < numberOfEmenies; i++)
		{
			var enemyXPosition = Random.Range(generatorXPosition - xHalf, generatorXPosition + xHalf);
			var speed = Random.Range(1f, 5f);

			var enemyPosition = new Vector3(enemyXPosition, transform.position.y, 0f);
			var enemy = CreateEnemy(enemyPosition);
			enemy.AdjustScale();
			enemy.Destination = Destination.GetRandomDestination();
			enemy.Speed = speed;

			Counter.CountCreated();
		}

		var delay = Random.Range(1, 6);
		yield return new WaitForSeconds(delay);

		StartCoroutine(GenerateEnemies());
	}

	private Enemy CreateEnemy(Vector3 position)
	{
		var enemyInstance = _enemyPool.Where(x => !x.gameObject.activeSelf).FirstOrDefault();
		if (enemyInstance == null)
		{
			enemyInstance = Instantiate<Enemy>(EnemyPrefab, position, Quaternion.identity);
			enemyInstance.Origin = position;
			enemyInstance.Destination = Destination.transform.position;

			_enemyPool.Add(enemyInstance);
		}
		else
		{
			enemyInstance.transform.position = position;
			enemyInstance.gameObject.SetActive(true);
		}

		return enemyInstance;
	}
}
