using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Instance already exist");
            Destroy(gameObject);
        }

    }

    [SerializeField]
    float startHP = 100;

    float currentHP = 100;

    public void ApplyDamage(float damage)
    {
        currentHP -= damage;
        ScoreManager.Instance.UpdateHPValue(currentHP);

        if (currentHP < 0)
        {
            Debug.Log("Game Over");
        }
    }
}
