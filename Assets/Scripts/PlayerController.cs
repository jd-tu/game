using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody playerRb; 
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public AudioClip crashSound;

    private float speed = 30.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;
    public int pointValue;
    // public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(gameManager.isGameActive)
        {
            if(collision.gameObject.CompareTag("Animal")){
                gameManager.GameOver();

                // isOnGround = true;
                // dirtParticle.Play();
            } else if(collision.gameObject.CompareTag("Diamond")){
                // explosionParticle.transform.position = this.transform.position;

                gameManager.UpdateScore(pointValue);
                explosionParticle.Play();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                Destroy(collision.gameObject);

                // gameOver = true;
                // playerAnim.SetBool("Death_b", true);
                // playerAnim.SetInteger("DeathType_int", 1);
                // dirtParticle.Stop();
            }
        }
    }
}
