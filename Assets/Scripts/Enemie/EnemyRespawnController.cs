using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnemyRespawnController : MonoBehaviour
{
    public GameObject enemiePrefab;

    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    private int respawnTimeMiliseconds = 400;

    private Stopwatch stopwatch = new Stopwatch();

    private float timeToStartSpawing = 3;

    void Start()
    {
        StartCoroutine(EnableSpawning());
    }

    IEnumerator EnableSpawning()
    {
        yield return new WaitForSeconds(timeToStartSpawing);

        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerBase.Instance.IsGameRunning)
            return;

        if (stopwatch.ElapsedMilliseconds >= respawnTimeMiliseconds)
        {
            var position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

            var xPosition = position.x + Random.Range(-5f, 5f);
            var zPosition = position.z + Random.Range(-5f, 5f);

            position = new Vector3(xPosition, position.y, zPosition);

            var enemy = Instantiate(enemiePrefab, position, Quaternion.identity);
            enemy.transform.SetParent(transform);

            stopwatch.Restart();
            stopwatch.Start();
        }
    }
}