using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float score;
    public float lerpSpeed;
    public Transform startPosition;
    private PlayerControler playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
        score = 0;
        playerControlerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControlerScript.gameOver)
        {
            if (playerControlerScript.dubboleSpeed)
            {
                score += 2; 
            }
            else
            {
                score ++;
            }
            Debug.Log("Score: " +score);
        }
    }
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControlerScript.transform.position;
        Vector3 endPos = startPosition.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCoverd = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCoverd / journeyLength;

        playerControlerScript.GetComponent<Animator>().SetFloat("Speed_Multipler", 0.5f);

        while(fractionOfJourney < 1)
        {
            distanceCoverd = (Time.time -startTime) * lerpSpeed;
            fractionOfJourney = (distanceCoverd / journeyLength);
            playerControlerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }
        playerControlerScript.GetComponent<Animator>().SetFloat("Speed_Multipler", 1.0f);
        playerControlerScript.gameOver = false;
    }

}
