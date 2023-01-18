using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefab;

    private Vector3 spawnPosition = new Vector3(25, 0 , 0);
  
    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerControler playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
        InvokeRepeating("spawnObs", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnObs()
    {
        int index = Random.Range(0, spawnPrefab.Length);
        if(playerControlerScript.gameOver == false)
        {
            Instantiate(spawnPrefab[index], spawnPosition, spawnPrefab[index].transform.rotation);
        }
        
    }
}
