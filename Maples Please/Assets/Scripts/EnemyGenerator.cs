using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public Enemy EnemyPrefab;
	public GameObject Destination;
	public EnemyCounter Counter;

	private List<Enemy> _enemyPool = new List<Enemy>();

	void Start()
	{
		StartCoroutine(GenerateEnemies());
	}


	void Update()
	{
		
	}

	private IEnumerator GenerateEnemies()
	{
		var numberOfEmenies = Random.Range(1, 5);

		for (var i = 0; i < numberOfEmenies; i++)
		{
			var position = Random.Range(-10f, 10f);
			var speed = Random.Range(1f, 5f);

			var enemyPosition = new Vector3(position, transform.position.y, 0f);
			var enemy = CreateEnemy(enemyPosition);
			enemy.Destination.x = position;
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
