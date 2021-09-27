using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
   

    [Header("Settings")]
    [SerializeField] private bool isGameStarted;

    [SerializeField] private UnityEvent gameStart;
    [SerializeField] private UnityEvent jumpButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonUp;



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

}
