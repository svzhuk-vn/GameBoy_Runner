using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject playButton;

    public void OneGameStart() => this.playButton.SetActive(false);
}
