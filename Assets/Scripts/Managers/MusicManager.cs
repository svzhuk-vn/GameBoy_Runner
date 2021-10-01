using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audioSourse;

    [Header("Settings")]
    [SerializeField] private List<AudioClip> backgroundMusicClips;

    private void Awake()
    {
        if (this.audioSourse == null) this.audioSourse = GetComponent<AudioSource>();

        MusicManager[] musicManagerOnScene = FindObjectsOfType<MusicManager>();

        /*if (musicManagerOnScene.Length > 1)
        {
            Debug.Log("Delete duplicate music manager.");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Music manager move to dont destroy on load.");
            DontDestroyOnLoad(this.gameObject);
        }*/
    }

    private AudioClip GetRandomTrack()
    {
        int i = Random.Range(0, this.backgroundMusicClips.Count);
        return this.backgroundMusicClips[i];
    }

    private void Update()
    {
        if (this.audioSourse.isPlaying == false)
        {
            AudioClip clip = GetRandomTrack();
            this.audioSourse.PlayOneShot(clip);

        }
    }


}
