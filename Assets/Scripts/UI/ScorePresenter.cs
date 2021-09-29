using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class ScorePresenter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        if (this.scoreText == null) this.scoreText = GetComponent<Text>();

    }

    public void OnScoreChanged(int score) => this.scoreText.text = score.ToString();
}
