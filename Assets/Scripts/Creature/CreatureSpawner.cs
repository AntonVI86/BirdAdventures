using System.Collections;
using UnityEngine;

public class CreatureSpawner : Spawner
{
    [SerializeField] private Bird _bird;
    [SerializeField] protected ScoreCounter ScoreCounter;

    private float _minTimeBetweenSpawn = 3;
    private float _maxTimeBetweenSpawn = 7;

    private void Awake()
    {
        Init(Templates);
        StartCoroutine(StartSpawn());
    }

    protected override IEnumerator StartSpawn()
    {
        while(true)
        {
            TimeBetweenSpawn = Random.Range(_minTimeBetweenSpawn, _maxTimeBetweenSpawn);

            TryActivateObject();

            yield return new WaitForSeconds(TimeBetweenSpawn);
        }
    }

    protected override void TryActivateObject()
    {
        if (TryGetObject(out GameObject creature))
        {
            int index = Random.Range(0, SpawnPoint.Length);

            creature.SetActive(true);
            creature.GetComponent<CreatureMover>().ResetCreature();
            creature.transform.position = SpawnPoint[index].position;
            creature.GetComponent<CreatureMover>().SetDirection(_bird);
            creature.GetComponent<Creature>().GiveReward += OnSoiled;
            creature.GetComponent<Creature>().Clear();
        }
    }

    private void OnSoiled(int reward, Creature creature)
    {
        ScoreCounter.AddScore(reward);
        creature.GiveReward -= OnSoiled;
    }
}
