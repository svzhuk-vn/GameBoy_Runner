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
    [SerializeField] private float nonLessDeltaTime;
    [Space]
    [SerializeField] private int scoreCount;
    [SerializeField] private int hightScoreCount;

    [SerializeField] private UnityEvent<int> scoreChanged;
    [SerializeField] private UnityEvent<int> hightScoreChanged;

    private IEnumerator ScoreCounter()
    {

        while (true)
        { 
            this.scoreCount += this.addScorePerIteration;
            this.scoreChanged?.Invoke(this.scoreCount);

            if (this.scoreCount > this.hightScoreCount)
            {

                this.hightScoreCount = this.scoreCount;
                this.hightScoreChanged?.Invoke(this.hightScoreCount);
            }
            yield return new WaitForSeconds(this.iterationDelta);
        }

        


    }

    private IEnumerator IterationDeltaCounter()
    {
        yield return new WaitForSeconds(this.nonLessDeltaTime);
        while (true)
        {
            this.iterationDelta -= this.lessDeltaPerSecond / 10;
            this.iterationDelta = Mathf.Clamp(this.iterationDelta, this.minIterationDelta, this.maxIterationDelta);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnGameStart()
    {
        StartCoroutine(ScoreCounter());
        StartCoroutine(IterationDeltaCounter());
    }

    public void OnPlayedDead()

    {
        StopAllCoroutines();
    }

}



