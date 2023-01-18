using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 30.0f;

    private PlayerControler playerControlerScript;

    private float leftBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlerScript.gameOver == false )
        {
            if(playerControlerScript.dubboleSpeed)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (moveSpeed * 2));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
