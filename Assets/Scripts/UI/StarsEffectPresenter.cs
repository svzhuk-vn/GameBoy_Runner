using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsEffectPresenter : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Components")]
    [SerializeField] private GameObject staticParticles;
    [SerializeField] private GameObject dynamicParticles;
    [SerializeField] private Animator staticParticlesAnimator;

    private static readonly int GameStart = Animator.StringToHash("GameStart");

    public void OnGameStart()
    {
        this.staticParticlesAnimator.SetTrigger(GameStart);
        this.dynamicParticles.SetActive(true);
    }
}
