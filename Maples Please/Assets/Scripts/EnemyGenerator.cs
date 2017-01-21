using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public Enemy EnemyPrefab;
	public GameObject Destination;
	private List<Enemy> _enemyPool = new List<Enemy>();
	private int _enemyPoolSize = 15;

	void Start()
	{

	}


	void Update()
	{
		StartCoroutine(GenerateEnemies());
	}

	private IEnumerator GenerateEnemies()
	{
		var delay = Random.Range(3, 15);
		yield return new WaitForSeconds(delay);

		var numberOfEmenies = Random.Range(1, 5);

		for(var i=0; i < numberOfEmenies; i++)
		{
			var position = Random.Range(-5.5f, 5.5f);
			var speed = Random.Range(-1, -5);

			var enemyPosition = new Vector3(position, transform.position.y, 0f);
			var enemy = CreateEnemy(enemyPosition);
			enemy.Speed = speed;
		}

		StartCoroutine(GenerateEnemies());
	}

	private Enemy CreateEnemy(Vector3 position)
	{
		var enemyInstance = _enemyPool.Where(x => !x.enabled).FirstOrDefault();
		if (enemyInstance == null)
		{
			enemyInstance = Instantiate<Enemy>(EnemyPrefab, position, Quaternion.identity);

			_enemyPool.Add(enemyInstance);
		}

		return enemyInstance;
	}
}
