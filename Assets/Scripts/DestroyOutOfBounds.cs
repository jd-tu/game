using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 900;
    private float lowerBound = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > topBound)
        {
            Debug.Log("kukooo");
            Destroy(gameObject);
        } else if (transform.position.x < lowerBound)
        {
            Debug.Log("kuk");
            Destroy(gameObject);
        }
    }
}
