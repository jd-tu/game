using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;
    public GameObject titleScreen;
    public GameObject[] DiamondPrefabs;
    public GameObject player;

    // private float spawnRangeX = 920;
    // private float spawnPosZ = 600;
    private float startDelay = 3;
    // private float spawnInterval = 3f;  
    private float playerXpos;



    private int score;
    private float spawnRate = 1.0f;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        // gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // player = GameObject.Find("Player");

        // Debug.Log(gameManager.isGameActive);
        // StartCoroutine(SpawnTarget());            
    }

    // Update is called once per frame
    void Update()
    {
        playerXpos = player.transform.position.x + 300;      
    }
     
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

  
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);

        player = GameObject.Find("Player");
        spawnRate /= difficulty;
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(startDelay);
            int index = Random.Range(0, DiamondPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range((playerXpos - 200), playerXpos), 300, Random.Range(630, 660));

            Instantiate(DiamondPrefabs[index], spawnPos, DiamondPrefabs[index].transform.rotation);
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
