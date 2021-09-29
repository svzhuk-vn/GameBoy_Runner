using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class ScoreSoundController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audioSourse;

    [Header("Settings")]
    [SerializeField] private AudioClip scoreEven100Sounds;
    [SerializeField] private AudioClip scoreEven250Sounds;
    [SerializeField] private AudioClip scoreEven500Sounds;

    private void Awake()
    {
        if (this.audioSourse == null) this.audioSourse = GetComponent<AudioSource>();

    }

    private bool IsEvenNumber(int value, int number) => value % number == 0;

    public void OnScoreChanged(int score)
    {
        if (IsEvenNumber(score, 500)) this.audioSourse.PlayOneShot(this.scoreEven500Sounds);
        else if (IsEvenNumber(score, 250)) this.audioSourse.PlayOneShot(this.scoreEven250Sounds);
        else if (IsEvenNumber(score, 100)) this.audioSourse.PlayOneShot(this.scoreEven100Sounds);




    }

}
