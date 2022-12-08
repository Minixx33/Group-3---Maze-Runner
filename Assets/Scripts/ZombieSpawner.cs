using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    //The Zombie
    public GameObject zombies;
    public Transform[] spawnPositions;
    private float timePassed;
    private float pauseSpawn;
    private float spawnSpeed = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        pauseSpawn = spawnSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        timePassed = Time.realtimeSinceStartup;
        if(Math.Round(timePassed) % 10 == 0 && pauseSpawn < 0)
        {
            SpawnNewZombie();
            pauseSpawn = spawnSpeed;
        }

        //0.0138 is the amount subtracted every frame which is equal to 1 per second or (1/72)
        pauseSpawn -= 0.0138f;
    }

    public void SpawnNewZombie()
    {
        new WaitForSeconds(UnityEngine.Random.Range(0, 5));
        GameObject zombie = Instantiate(zombies, spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)]);
        zombie.transform.localPosition = Vector3.zero;
    }
}
