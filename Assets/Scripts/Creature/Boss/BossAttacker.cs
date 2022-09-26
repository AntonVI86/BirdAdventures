using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private BossBullet _bulletTemplate;
    [SerializeField] private Transform _shootPoint;

    public void OnShoot()
    {
        BossBullet newBullet = Instantiate(_bulletTemplate, _shootPoint);
        newBullet.Move(_bird, _shootPoint);
    }
}
