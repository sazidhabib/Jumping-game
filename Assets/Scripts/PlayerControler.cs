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

    public float jumpForce = 10;
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
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            DritEffect.Stop();
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);
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
