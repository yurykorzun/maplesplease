using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mountie : MonoBehaviour
{
	public HUDAttackManager HUDAttack;
	public GameRounds Rounds;
	private List<Puck> _puckPool = new List<Puck>();

	private DateTime _timeOfLastAttack = DateTime.MinValue;

    public int AttackPower;
    public float FireDelay;

    public Puck Puck;

	private int _pucksCreated;

	private void Awake()
	{
		Rounds.RoundStarted += RoundStarted;
	}

	void RoundStarted(int round)
	{
		_pucksCreated = 0;
		HUDAttack.SetPucks(Rounds.CurrentRound.PucksLimit);
	}

    void Update()
    {
		var pucksAvailable = _pucksCreated < Rounds.CurrentRound.PucksLimit;
		
		if (pucksAvailable && Input.GetMouseButtonDown(0) && (DateTime.Now - _timeOfLastAttack).TotalMilliseconds >= FireDelay)
        {
            _timeOfLastAttack = DateTime.Now;
            
            var animator = gameObject.GetComponent<Animator>();
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition;

            var vectorFromMountieToMouse = mousePosition - gameObject.transform.position;
            var angle = Vector2.Angle(transform.up, vectorFromMountieToMouse);

			var puck = CreateEnemy(gameObject.transform.position, vectorFromMountieToMouse);

            if (mousePosition.x < gameObject.transform.position.x)
            {
                if (angle <= 22.5f)
                {
                    animator.SetTrigger("ClickNNW");
                }
                else if (angle <= 45f)
                {
                    animator.SetTrigger("ClickNW");
                }
                else if (angle <= 67.5f)
                {
                    animator.SetTrigger("ClickWNW");
                }
                else
                {
                    animator.SetTrigger("ClickW");
                }
            }
            else
            {
                if (angle <= 22.5f)
                {
                    animator.SetTrigger("ClickNNE");
                }
                else if (angle <= 45f)
                {
                    animator.SetTrigger("ClickNE");
                }
                else if (angle <= 67.5f)
                {
                    animator.SetTrigger("ClickENE");
                }
                else
                {
                    animator.SetTrigger("ClickE");
                }
            }
        }
    }

	private Puck CreateEnemy(Vector3 position, Vector2 vectorFromMountieToMouse)
	{
		var puckInstance = _puckPool.Where(x => !x.gameObject.activeSelf).FirstOrDefault();
		if (puckInstance == null)
		{
			puckInstance = Instantiate<Puck>(Puck, gameObject.transform.position, Quaternion.identity);
			puckInstance.name = "Puck";
			_puckPool.Add(puckInstance);
		}
		else
		{
			puckInstance.transform.position = position;
			puckInstance.gameObject.SetActive(true);
		}
		puckInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(vectorFromMountieToMouse.x, vectorFromMountieToMouse.y).normalized * AttackPower;

		_pucksCreated++;
		HUDAttack.SetPucks(Rounds.CurrentRound.PucksLimit - _pucksCreated);

		return puckInstance;
	}
}