using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
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
