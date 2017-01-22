using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameRounds Rounds;
	public Enemy EnemyPrefab;
	public EnemyDestination Destination;
	public EnemyReturn Return;

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
		var numberOfEmenies = Rounds.GetEnemiesNumber();
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
			enemy.name = "Enemy";
			enemy.Destination = Destination.GetRandomDestination();
			enemy.Speed = Rounds.GetSpeed();
			enemy.Return = Return.GetRandomDestination();
			enemy.WaitSeconds = Rounds.GetWaitSeconds();

			Counter.CountCreated();
		}

		var delay = Rounds.GetDelay();
		yield return new WaitForSeconds(Random.Range(delay-0.2f, delay + 0.2f));

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


		enemyInstance.transform.localScale = new Vector3
		{
			x = 1f,
			y = 1f,
			z = enemyInstance.transform.localScale.z
		};

        //   var vector = enemyInstance.Destination - enemyInstance.Origin;
        //if (vector.ToAngleInDegrees() <= 15)
        //{
        //    enemyInstance.GetComponent<Animator>().SendMessage(@"GoForward");
        //}
        //   else if (enemyInstance.Origin.x < enemyInstance.Destination.x)
        //{
        //    enemyInstance.GetComponent<Animator>().SendMessage(@"GoRight");
        //}
        //else
        //   {
        //       enemyInstance.GetComponent<Animator>().SendMessage(@"GoLeft");
        //   }

        //if (Mathf.Abs(enemyInstance.Origin.x - enemyInstance.Destination.x) <= 2)
        ////if (vector.ToAngleInDegrees() <= 5)
        //{
        //    enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoForward");
        //}
        //else if (enemyInstance.Origin.x < enemyInstance.Destination.x)
        //{
        //    enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoRight");
        //}
        //else
        //{
        //    enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoLeft");
        //}

        //   var next = Vector3.MoveTowards(enemyInstance.Origin, enemyInstance.Destination, 4 * Time.deltaTime);
        //var deltaX = next.x - enemyInstance.Origin.x;

        //if (deltaX < -0.01)
        //   {
        //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoLeft");
        //   }
        //   else if (deltaX >= 0.01)
        //{
        //    enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoRight");
        //}
        //else
        //{
        //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoForward");
        //   }


     //   var targetVector = enemyInstance.Destination - enemyInstance.Origin;
     //   var angle = targetVector.ToAngleInDegrees();
	    //if (angle <= -105f)
	    //{
     //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoRight");
     //       //enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoLeft");
     //   }
     //   else if (angle >= -75f)
	    //{
     //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoLeft");
     //       //enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoRight");
     //   }
	    //else
	    //{
     //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoForward");
     //   }



            //GetComponent<SpriteRenderer>().sprite = angle >= -90 && angle < 60 ? _rightSprite :
            //                                        angle >= 50 && angle < 120 ? _centerSprite :
            //                                        _leftSprite;

            //   var dest = Camera.main.WorldToScreenPoint(enemyInstance.Destination);
            //   var orig = Camera.main.WorldToScreenPoint(enemyInstance.Origin);
            //var vectorFromOriginToDestination = dest - orig;
            //   var angle = Vector2.Angle(transform.up * -1, vectorFromOriginToDestination);

            //   if (angle <= 15)
            //   {
            //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoForward");
            //   }
            //   else if (orig.x < dest.x)
            //   {
            //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoLeft");
            //   }
            //   else
            //   {
            //       enemyInstance.gameObject.GetComponent<Animator>().SetTrigger(@"GoRight");
            //   }

            return enemyInstance;
	}
}
