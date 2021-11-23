using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AnimalPrefabs;
    private float spawnRangeX = 920;
    private float spawnPosZ = 600;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;  

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
            int animalIndex = Random.Range(0, AnimalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 300, spawnPosZ);

            Instantiate(AnimalPrefabs[animalIndex], spawnPos, AnimalPrefabs[animalIndex].transform.rotation);
    }
}
