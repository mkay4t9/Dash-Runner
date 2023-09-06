using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControlls : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem explosionParticle, dirtParticle;
    private AudioSource playerAudio;
    public AudioClip jumpAudio, crashAudio;
    public float jumpForce = 10;
    public bool gameover = true;
    private int jumpCount = 0;

    public Transform startPos;
    public float lerpSpeed;
    public GameObject gameOverPannel;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameover = true;
        // StartCoroutine(playIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            playerAnim.SetFloat("Speed_f", 0.6f);
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !gameover)
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCount++;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpAudio, 1.0f);
            }

            if (Input.GetKey(KeyCode.LeftShift) && !gameover)
            {
                Time.timeScale = 3.0f;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        else
            Time.timeScale = 0;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameover = true;
            gameOverPannel.SetActive(true);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashAudio, 1.0f);
        }
    }
}