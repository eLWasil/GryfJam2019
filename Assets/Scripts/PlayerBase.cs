using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase Instance { get; private set; }
    [SerializeField]
    float startHP = 100;

    public float currentHP  { get; set; }

    private void Awake()
    {
        currentHP = 100;

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
