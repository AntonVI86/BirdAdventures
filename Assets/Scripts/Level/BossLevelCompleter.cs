using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelCompleter : MonoBehaviour
{
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private BossHealth _boss;
    [SerializeField] private ScoreCounter _counter;

    private void OnEnable()
    {
        _boss.Strucked += _levelEnder.OnEndLevel;
        _boss.Strucked += OnAddScore;
    }

    private void OnDisable()
    {
        _boss.Strucked -= _levelEnder.OnEndLevel;
        _boss.Strucked -= OnAddScore;
    }

    private void OnAddScore()
    {
        _counter.AddScore(1);
    }
}
