using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimation;

    public ParticleSystem ExplosionEffect;
    public ParticleSystem DritEffect;

    private AudioSource PlayerAudio;
    public AudioClip jumpSound;
    public AudioClip crushSound;

    public float jumpForce = 700.0f;
    public float DoubleJumpForce = 400.0f;

    private bool dubboleJumpUsed = true;
    public bool dubboleSpeed = false;

    public float gravityForce;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityForce;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver != true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dubboleJumpUsed = false;
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            DritEffect.Stop();
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);    
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !dubboleJumpUsed)
        {
            dubboleJumpUsed = true;
            playerRb.AddForce(Vector3.up * DoubleJumpForce, ForceMode.Impulse);
            playerAnimation.Play("Running_Jump",3,0f);
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dubboleSpeed = true;
            playerAnimation.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (dubboleSpeed)
        {
            dubboleSpeed = false;
            playerAnimation.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            DritEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            
            Debug.Log("Game Over");
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            ExplosionEffect.Play();
            DritEffect.Stop();
            PlayerAudio.PlayOneShot(crushSound, 1.0f);
            
        }
        
    }
}
