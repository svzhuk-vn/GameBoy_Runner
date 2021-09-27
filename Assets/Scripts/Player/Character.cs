using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Assets.Scripts.Player
{ 


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CharacterMovementController))]
[RequireComponent(typeof(CharacterAnimationController))]
[RequireComponent(typeof(CharacterSoundController))]



public class Character : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private CharacterMovementController characterMovement;
    [SerializeField] private CharacterAnimationController characterAnimation;
    [SerializeField] private CharacterSoundController characterSound;

        [SerializeField] private UnityEvent jump;
        [SerializeField] private UnityEvent dead;
        [SerializeField] private UnityEvent crouchRunStart;
        [SerializeField] private UnityEvent crouchRunEnd;

        private void Awake()
        {

            if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovementController>();
            if (this.characterAnimation == null) this.characterAnimation = GetComponent<CharacterAnimationController>();
            if (this.characterSound == null) this.characterSound = GetComponent<CharacterSoundController>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.tag)
                { 
                    case "Obstacle":
                    this.dead?.Invoke();
                    Debug.Log("{<color=lime><b> Character Log </b></color> => [Character] - (<color=yellow>OnCollisionEnter2d</color> - > Character dead.}");
                    break;

            }

        }


        public void OnJumpButton()
            {
            bool idGround = this.characterMovement.IsGround();
            if (idGround)
            {
                this.characterMovement.Jump();
                this.characterAnimation.SetJump();
                this.characterSound.PlayJumpSound();
                this.jump?.Invoke();

            }
            
            }
        public void OnCrouchRunButtonDown()
        {
            bool isGround = this.characterMovement.IsGround();
            if (isGround)
            {
                this.characterAnimation.SetCrouchRun(true);
                this.crouchRunStart?.Invoke();

            }

        
        }
        public void OnCrouchRunButtonUp()
        {
            this.characterAnimation.SetCrouchRun(false);
            this.crouchRunEnd?.Invoke();

        }

        public void OnGameStart() => this.characterAnimation.SetGameStart();
        
        

    }
}