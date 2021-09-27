using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int addScorePerIteration;
    [SerializeField] private float iterationDelta;
    [SerializeField] private float minIterationDelta;
    [SerializeField] private float maxIterationDelta;
    [SerializeField] private float lessDeltaPerSecond;
    [Space]
    [SerializeField] private int scoreCount;
    [SerializeField] private int hightScoreCount;

    [SerializeField] private UnityEvent<int> scoreChanged;
    [SerializeField] private UnityEvent<int> hightScoreChanged;

    private IEnumerator ScoreCounter()
    {
        yield break;


    }


    public void OnGameStart()
    {
        StartCoroutine(ScoreCounter());
    }

    public void OnPlayedDead()

    {
        StopAllCoroutines();
    }

}



