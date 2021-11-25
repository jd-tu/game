using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] DiamondPrefabs;
    public GameObject player;
    private float spawnRangeX = 920;
    private float spawnPosZ = 600;
    private float startDelay = 1;
    private float spawnInterval = 3f;  
    private float playerXpos;
private int spawnDistance = 10; // How far away to spawn
private int  moveDistance = 10; // How far away to spawn

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        playerXpos = player.transform.position.x + 300;      
    }

     IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            int index = Random.Range(0, DiamondPrefabs.Length);
            // Instantiate(DiamondPrefabs[index]);
            Vector3 spawnPos = new Vector3(Random.Range((playerXpos - 200), playerXpos), 300, Random.Range(630, 660));

            Instantiate(DiamondPrefabs[index], spawnPos, DiamondPrefabs[index].transform.rotation);
        }
    }
}
