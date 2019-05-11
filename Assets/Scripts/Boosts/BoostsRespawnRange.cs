using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoostsRespawnRange : MonoBehaviour
{
    public GameObject boostsPrefab;
    public Vector2 size;
    private Stopwatch stopwatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch.ElapsedMilliseconds >= 1000)
        {
            float xPos = Random.Range(-size.x / 2, size.x / 2);
            float zPos = Random.Range(-size.y / 2, size.y / 2);

            var boost = Instantiate(boostsPrefab, transform.position + new Vector3(xPos, 6, zPos), Quaternion.identity);
            boost.transform.SetParent(transform);
            Destroy(boost, 15);

            stopwatch.Restart();
            stopwatch.Start();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, 0, size.y));
    }
}
