﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public HUDAttackManager HUDAttack;
    public GameRounds Rounds;
    public Bullet BulletPrototype;
    private List<Bullet> _bulletPool = new List<Bullet>();
    private int _bulletsFired;
    
    private void Awake()
    {
        Rounds.RoundStarted += OnRoundStarted;
    }
	
    void OnRoundStarted(int round)
    {
        _bulletsFired = 0;
    }

    public bool GenerateBullet(Vector3 position, Vector2 vectorFromMountieToMouse)
    {
        // hack #1 - cuz im out of time!
        var bulletsLimit = BulletPrototype is Puck ? Rounds.CurrentRound.PucksLimit : Rounds.CurrentRound.LeafsLimit;        
        if (_bulletsFired >= bulletsLimit)
        {
            return false;
        }

        var bullet = _bulletPool.Where(x => !x.gameObject.activeSelf).FirstOrDefault();
        if (bullet == null)
        {
            bullet = BulletPrototype.CloneInstance();
            _bulletPool.Add(bullet);
        }

        bullet.Fire(position, vectorFromMountieToMouse);
        _bulletsFired++;

        // hack #2 - cuz im out of time!
        if (BulletPrototype is Puck)
        {
            HUDAttack.SetPucks(Rounds.CurrentRound.PucksLimit - _bulletsFired);
        }
        else
        {
            HUDAttack.SetLeafs(Rounds.CurrentRound.LeafsLimit - _bulletsFired);
        }

        return true;
    }
}
