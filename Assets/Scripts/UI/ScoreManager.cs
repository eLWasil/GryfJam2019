using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField]
    Text[] scoreText;

    [SerializeField]
    Text hpText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(PlayerId playerID, float score)
    {
        var id = (int)playerID - 1;

        if (id < 0 || id >= scoreText.Length)
            return;

        scoreText[id].text = playerID.ToString() + ": " + score;
    }

    public void UpdateHPValue(float hp)
    {
        hpText.text = "HP: " + hp;
    }
}
