using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase Instance { get; private set; }

    [SerializeField]
    float startHP = 100;

    float currentHP;

    public bool IsGameRunning { get { return currentHP > 0; } }

    private void Awake()
    {
        currentHP = startHP;
        
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
        if (currentHP < 0)
            return;

        currentHP -= damage;
        UIManager.Instance.UpdateHPValue(currentHP);

        if (currentHP <= 0)
        {
            UIManager.Instance.ShowGameOverScreen();
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
