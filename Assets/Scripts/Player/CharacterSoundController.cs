using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(AudioSource))]

    public class CharacterSoundController : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField] private AudioSource audioSource;

        [Header("Settings")]
        [SerializeField] private List<AudioClip> jumpSounds;
        [SerializeField] private List<AudioClip> deathSounds;

        private void Awake()
        {
            if (this.audioSource == null) this.audioSource = GetComponent<AudioSource>();
        }


        public void PlayJumpSound()
        {
            int i = Random.Range(0, this.jumpSounds.Count);
            this.audioSource.PlayOneShot(this.jumpSounds[i]);
        
        }

        public void PlayDeathSound()
        {
            int i = Random.Range(0, this.deathSounds.Count);
            this.audioSource.PlayOneShot(this.deathSounds[i]);

        }

    }
}