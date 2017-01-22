using System.Collections.Generic;
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
        HUDAttack.SetPucks(Rounds.CurrentRound.PucksLimit);
    }

    public bool GenerateBullet(Vector3 position, Vector2 vectorFromMountieToMouse)
    {
        var limitReached = _bulletsFired >= Rounds.CurrentRound.PucksLimit;   
        if (limitReached)
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
        HUDAttack.SetPucks(Rounds.CurrentRound.PucksLimit - _bulletsFired);

        return true;
    }
}
