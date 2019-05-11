using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    public const int BONUS_TIME_MILISEC = 15 * 1000;

    public enum boostTypes
    {
        NONE,
        SPEED,
        POWER,
        GRENADE_HEAL
    }

    [SerializeField]
    Vector3 rotations;

    public boostTypes bType;

    // Start is called before the first frame update
    void Start()
    {
        int maxEnum = System.Enum.GetNames(typeof(boostTypes)).Length;
        int randomBoostVal = (int)Random.Range(1, maxEnum);

        bType = (boostTypes)randomBoostVal;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotations * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();

        if (player == null) return;

        player.activeBoost = bType;
        Destroy(gameObject);

        BoostsRespawnRange.boostsOnScene--;
    }

}
