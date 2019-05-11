using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrace : MonoBehaviour
{
    public float speed;
    public GameObject granary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float granaryLeftBorder  = granary.transform.position.x - (granary.transform.localScale.x / 2);
        float granaryRightBorder = granary.transform.position.x + (granary.transform.localScale.x / 2);
        float granaryTopBorder   = granary.transform.position.z + (granary.transform.localScale.z / 2);
        float granaryBotBorder   = granary.transform.position.z - (granary.transform.localScale.z / 2);

        Debug.Log(granaryBotBorder + ", " + granaryLeftBorder + ", " + granaryTopBorder + ", " + granaryRightBorder);

        if (transform.position.x < granaryLeftBorder)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > granaryRightBorder)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if (transform.position.z < granaryBotBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }
        else if (transform.position.z > granaryTopBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }

        if (granaryLeftBorder < transform.position.x && granaryRightBorder > transform.position.x)
        {
            if (granaryBotBorder < transform.position.z && granaryTopBorder > transform.position.z)
            {
                Debug.Log("Destroyed");
                Destroy(gameObject);
            }
        }

    }


}
