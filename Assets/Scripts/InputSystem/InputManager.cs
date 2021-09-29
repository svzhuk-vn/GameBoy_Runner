using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
   

    [Header("Settings")]
    [SerializeField] private bool isGameStarted;
    [SerializeField] private bool isPlayerDead;

    [SerializeField] private UnityEvent gameStart;
    [SerializeField] private UnityEvent jumpButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonUp;
    [SerializeField] private UnityEvent restartLevel;



    public void OnPlayButtonDown()
    {
        if (this.isGameStarted == false)
        {
            this.isGameStarted = true;
            this.gameStart?.Invoke();
            Debug.Log("Game Started");
        }
    }

    public void OnJumpButtonDown()
    {
        this.jumpButtonDown?.Invoke();
        Debug.Log("Jump");
    }

    public void OnCrouchRunButtonDown()
    {
        this.crouchRunButtonDown?.Invoke();
        Debug.Log("Crouch on");
    }

    public void OnCrouchRunButtonUp()
    {
        this.crouchRunButtonUp?.Invoke();
        Debug.Log("Crouch off");
    }

    public void OnPlayedDead() => this.isPlayerDead = true;

    public void OnRestartLevelButtonDown()
    {
        if (this.isPlayerDead)
        {
            this.restartLevel?.Invoke();
            Debug.Log("Played dead");
        }
    }

}
