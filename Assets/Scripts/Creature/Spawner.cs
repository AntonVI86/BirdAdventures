using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ObjectPool
{
    [SerializeField] protected GameObject[] Templates;
    [SerializeField] protected Transform[] SpawnPoint;
    
    protected float TimeBetweenSpawn;

    protected abstract IEnumerator StartSpawn();

    protected abstract void TryActivateObject();
}
