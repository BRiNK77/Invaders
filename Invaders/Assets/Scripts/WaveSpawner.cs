using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject alienPrefab;
    public int totalWaves;
    public int aliensPerWave;
    public Transform[] spawns;
    public GameObject exitDoor;

    private int aliensLeft;
    private int currentWave = 0;
    private bool waveDone = true;
    private bool waveWait = false;
    private bool spawnWait = false;
    private bool levelDone = false;

    // Start is called before the first frame update
    void Start()
    {
        aliensLeft = aliensPerWave;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if level is done
        if (!levelDone)
        {
            //Check if waves are done and if any aliens are left
            if (currentWave == totalWaves && CheckForAliens())
            {
                exitDoor.transform.Rotate(0, 0, -90, Space.Self);
                levelDone = true;
                print("Find the exit");
                return;
            }

            if (waveDone)
            {
                aliensLeft = aliensPerWave;
                //Prepare for next wave
                if (!waveWait)
                {
                    currentWave++;
                    print("Starting wave: " + currentWave);
                    StartCoroutine("WaveWait");
                }
                return;
            }

            if (aliensLeft == 0 && CheckForAliens())
            {
                print("Wave Done!");
                waveDone = true;
                currentWave++;
            }
            else if (aliensLeft == aliensPerWave)
            {
                //Spawn aliens
                if (!spawnWait)
                {
                    StartCoroutine("SpawnAliens");
                }
            }
        }
    }

    IEnumerator WaveWait()
    {
        waveWait = true;
        yield return new WaitForSeconds(5);
        waveWait = false;
        waveDone = false;
    }

    IEnumerator SpawnAliens()
    {
        spawnWait = true;
        yield return new WaitForSeconds(1);

        for (int i = 0; i < aliensPerWave; i++)
        {
            int spawnLocation = Random.Range(0, spawns.Length);
            GameObject temp = Instantiate(alienPrefab, spawns[spawnLocation].localPosition, new Quaternion());
            yield return new WaitForSeconds(Random.Range(2, 6));
            aliensLeft--;
            print("Spawned Alien: " + i);
        }
        spawnWait = false;
    }

    bool CheckForAliens()
    {
        //If aliens found return true 
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            return true;
        return false;
    }
}
