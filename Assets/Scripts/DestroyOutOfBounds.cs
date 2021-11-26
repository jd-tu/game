using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameManager gameManager;

    private float topBound = 1000;
    private float lowerBound = 100;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > topBound)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        } else if (transform.position.x < lowerBound)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
