using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [RequireComponent(typeof(AudioSource))]

    public class HighScoreSoundController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private AudioSource audioSource;

        [Header("Settings")]
        [SerializeField] private List<AudioClip> highScoreChangedSounds;
        [SerializeField] private bool isSoundPlayed;


        private void Awake()
        {
            if (this.audioSource = null) this.audioSource = GetComponent<AudioSource>();
        }

        public void OnHighScoreChanged(int highScore)
        {
            if (this.isSoundPlayed == false)
            {
                this.isSoundPlayed = true;
                int i = Random.Range(0, this.highScoreChangedSounds.Count);
                this.audioSource.PlayOneShot(this.highScoreChangedSounds[i]);
                
            
            }
        
        }

    }


