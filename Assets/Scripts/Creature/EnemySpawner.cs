using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private float _minTimeBetweenSpawn = 5;
    private float _maxTimeBetweenSpawn = 10;

    private void Awake()
    {
        Init(Templates);
        StartCoroutine(StartSpawn());
    }

    protected override IEnumerator StartSpawn()
    {
        while (true)
        {
            TimeBetweenSpawn = Random.Range(_minTimeBetweenSpawn, _maxTimeBetweenSpawn);

            TryActivateObject();

            yield return new WaitForSeconds(TimeBetweenSpawn);
        }
    }

    protected override void TryActivateObject()
    {
        if (TryGetObject(out GameObject enemy))
        {
            int index = Random.Range(0, SpawnPoint.Length);

            enemy.SetActive(true);            
            enemy.transform.position = SpawnPoint[index].position;
        }
    }
}
