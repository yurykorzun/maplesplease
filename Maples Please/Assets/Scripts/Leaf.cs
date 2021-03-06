﻿using System.Collections;
using System.Linq;
using UnityEngine;

public class Leaf : Bullet
{
    public float RotationSpeed = 1;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Sprite _sprite;
	private AudioSource _splatSound;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<Sprite>();
		_splatSound = gameObject.GetComponentsInChildren<AudioSource>().Single(x => x.name == "Splat");
    }
	private IEnumerator DestroyDelayed()
	{
		yield return new WaitForSeconds(9f);

		gameObject.SetActive(false);
	}

	private void Update()
    {
        transform.Rotate(new Vector3(0, 0, RotationSpeed));
    }

    public override Bullet CloneInstance()
    {
        var instance = Instantiate(this, gameObject.transform.position, Quaternion.identity);
        instance.name = "Leaf";
        return instance;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Enemy")
        {
            OnHit(coll);
            coll.gameObject.SetActive(false);
        }
    }

    private void OnHit(Collider2D coll)
    {
        _rigidBody.velocity = new Vector2(0, 0);
        RotationSpeed = 0;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        _animator.SetTrigger("Land");

		_splatSound.enabled = true;
		_splatSound.Play();

		StartCoroutine(DestroyDelayed());
	}
}
