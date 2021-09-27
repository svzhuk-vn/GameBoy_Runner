using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButtonPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject controlButtonsContainer;


    public void OneGameStart() => this.controlButtonsContainer.SetActive(true);
}
