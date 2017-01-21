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
		StartCoroutine(GenerateEnemies());
	}


	void Update()
	{
		
	}

	private IEnumerator GenerateEnemies()
	{
		var numberOfEmenies = Random.Range(1, 7);

		for (var i = 0; i < numberOfEmenies; i++)
		{
			var position = Random.Range(-5.5f, 5.5f);
			var speed = Random.Range(-0.5f, -3f);

			var enemyPosition = new Vector3(position, transform.position.y, 0f);
			var enemy = CreateEnemy(enemyPosition);
			enemy.Speed = speed;
		}

		var delay = Random.Range(1, 3);
		yield return new WaitForSeconds(delay);

		StartCoroutine(GenerateEnemies());
	}

	private Enemy CreateEnemy(Vector3 position)
	{
		var enemyInstance = _enemyPool.Where(x => !x.gameObject.activeSelf).FirstOrDefault();
		if (enemyInstance == null)
		{
			enemyInstance = Instantiate<Enemy>(EnemyPrefab, position, Quaternion.identity);

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
