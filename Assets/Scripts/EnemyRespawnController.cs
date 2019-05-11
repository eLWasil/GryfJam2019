using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnemyRespawnController : MonoBehaviour
{
    public GameObject enemiePrefab;

    private Stopwatch stopwatch = new Stopwatch();
    private const int respawnTimeMiliseconds = 400;
    

    // Start is called before the first frame update
    void Start()
    {
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log("stopwatch.ElapsedMilliseconds = " + stopwatch.ElapsedMilliseconds);

        if (stopwatch.ElapsedMilliseconds >= respawnTimeMiliseconds)
        {
            bool isRespawnHorizontal = randomBoolean();

            float shortRangePosition = Random.Range(40.0f, 50.0f);
            float  longRangePosition = Random.Range(-50.0f, 50.0f);

            float xPos = 0;
            float zPos = 0;

            if (isRespawnHorizontal)
            {
                xPos = (randomBoolean() ? shortRangePosition : shortRangePosition * -1);
                zPos = longRangePosition;
            }
            else
            {
                zPos = (randomBoolean() ? shortRangePosition : shortRangePosition * -1);
                xPos = longRangePosition;
            }


            var enemy = Instantiate(enemiePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
            enemy.transform.SetParent(transform);

            stopwatch.Restart();
            stopwatch.Start();
        }
        //Debug.Log("enemies.Count: " + enemies.Count);

    }

    private bool randomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}
