using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;

    private Vector3 offset = new Vector3(-30, 30, 0);

 void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void LateUpdate()
    {
        if(gameManager.isGameActive)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
