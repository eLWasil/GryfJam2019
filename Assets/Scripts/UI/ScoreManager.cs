using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    Dictionary<PlayerInput, int> playerScores = new Dictionary<PlayerInput, int>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(PlayerInput player, int score)
    {
        int value;
        if (playerScores.TryGetValue(player, out value))
        {
            value += value;
        }
        else
        {
            playerScores.Add(player, score);
        }
    }
}
