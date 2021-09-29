using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject restartButton;

    public void OnPlayedDead() => this.restartButton.SetActive(true);
}
