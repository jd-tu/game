using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] DiamondPrefabs;
    public GameObject player;

    private float spawnRangeX = 920;
    private float spawnPosZ = 600;
    private float startDelay = 3;
    private float spawnInterval = 3f;  
    private float playerXpos;
private int spawnDistance = 10; // How far away to spawn
private int  moveDistance = 10; // How far away to spawn

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        player = GameObject.Find("Player");

        Debug.Log(gameManager.isGameActive);
        StartCoroutine(SpawnTarget());            
    }

    // Update is called once per frame
    void Update()
    {
        playerXpos = player.transform.position.x + 300;      
    }

     IEnumerator SpawnTarget()
    {
        while(gameManager.isGameActive)
        {
            yield return new WaitForSeconds(startDelay);
            int index = Random.Range(0, DiamondPrefabs.Length);
            // Instantiate(DiamondPrefabs[index]);
            Vector3 spawnPos = new Vector3(Random.Range((playerXpos - 200), playerXpos), 300, Random.Range(630, 660));

            Instantiate(DiamondPrefabs[index], spawnPos, DiamondPrefabs[index].transform.rotation);
        }
    }
}
