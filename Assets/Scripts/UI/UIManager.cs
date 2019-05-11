using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public static int stage = 1;

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    Text[] scoreText;

    [SerializeField]
    Text hpText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
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

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
