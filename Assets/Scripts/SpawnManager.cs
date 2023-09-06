using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2, repeatDelay = 2f;

    private PlayerControlls playerControllsScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
        InvokeRepeating("spawnObstacles", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacles()
    {
        int randomObstacle = Random.Range(0, obstaclePrefab.Length);
        if (playerControllsScript.gameover == false)
        {
            Instantiate(obstaclePrefab[randomObstacle], spawnPos, obstaclePrefab[randomObstacle].transform.rotation);   
        }
    }
}
