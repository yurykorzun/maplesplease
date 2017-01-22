using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Mountie : MonoBehaviour
{
    private Animator _animator;
    private BulletGenerator _puckGenerator;
    private BulletGenerator _leafGenerator;
	private DateTime _timeOfLastAttack = DateTime.MinValue;
    public float FireDelay;
    public AudioSource[] Sorries;
    public AudioSource[] Slapshots;
    public float SorryDelay;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _puckGenerator = gameObject.GetComponentsInChildren<BulletGenerator>().Single(x => x.name == "PuckGenerator");
        _leafGenerator = gameObject.GetComponentsInChildren<BulletGenerator>().Single(x => x.name == "LeafGenerator");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanFire())
        {
            Fire(_puckGenerator);
        }
        else if (Input.GetMouseButtonDown(1) && CanFire())
        {
            Fire(_leafGenerator);
        }
    }

    private bool CanFire()
    {
        return (DateTime.Now - _timeOfLastAttack).TotalMilliseconds >= FireDelay;
    }

    private IEnumerator MakeAttackNoises()
    {
        var slapshotIndex = UnityEngine.Random.Range(0, Slapshots.Length);
        var slapshot = Slapshots[slapshotIndex];
        slapshot.enabled = true;
        slapshot.Play();

        yield return new WaitForSeconds(SorryDelay);

        var sorryIndex = UnityEngine.Random.Range(0, Sorries.Length);
        var sorry = Sorries[sorryIndex];
        sorry.enabled = true;
        sorry.Play();
    }

    private void Fire(BulletGenerator bulletGenerator)
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var targetDirection = mousePosition - gameObject.transform.position;
        var wasBulletFired = bulletGenerator.GenerateBullet(gameObject.transform.position, targetDirection);

        if (wasBulletFired)
        {
            _timeOfLastAttack = DateTime.Now;
            SetAttackAngle(targetDirection, mousePosition);
            StartCoroutine(MakeAttackNoises());
        }
    }

    private void SetAttackAngle(Vector2 targetDirection, Vector2 mousePosition)
    {
        var angle = Vector2.Angle(transform.up, targetDirection);

        if (mousePosition.x < gameObject.transform.position.x)
        {
            if (angle <= 22.5f)
            {
                _animator.SetTrigger("ClickNNW");
            }
            else if (angle <= 45f)
            {
                _animator.SetTrigger("ClickNW");
            }
            else if (angle <= 67.5f)
            {
                _animator.SetTrigger("ClickWNW");
            }
            else
            {
                _animator.SetTrigger("ClickW");
            }
        }
        else
        {
            if (angle <= 22.5f)
            {
                _animator.SetTrigger("ClickNNE");
            }
            else if (angle <= 45f)
            {
                _animator.SetTrigger("ClickNE");
            }
            else if (angle <= 67.5f)
            {
                _animator.SetTrigger("ClickENE");
            }
            else
            {
                _animator.SetTrigger("ClickE");
            }
        }
    }
}