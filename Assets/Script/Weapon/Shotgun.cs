using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private Quaternion _bulletSpread;
    private int _numberOfBullets;
    private int _minSpread = -15;
    private int _maxSparead = 15;
    public override void Shoot(Transform shootPoint)
    {
        _numberOfBullets = Random.Range(3, 10);

            for (int i = 0; i < _numberOfBullets; i++)
            {
                _bulletSpread = Quaternion.Euler(0, 0, Random.Range(_minSpread, _maxSparead));
                Instantiate(Bullet, shootPoint.position, _bulletSpread);
            }
    }
}
