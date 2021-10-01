using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScorePresenter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Text highScoreText;

    [Header("Settings")]
    [SerializeField] private string prefix;

    private void Awake()
    {
        if (this.highScoreText == null) this.highScoreText = GetComponent<Text>();

    }

    public void OnDataLoaded(GameData data) => this.highScoreText.text = $"{this.prefix} {data.hightScoreCount}";
    public void OnHigtScoreChanged(int highScore) => this.highScoreText.text = $"{this.prefix} {highScore}";

}
