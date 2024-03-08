using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerFunctions : MonoBehaviour
{
    //Spawn Positions
    public Transform playerSpawnPos;
    public Transform enemySpawnPos;
    public Transform blueMinionSpawnPos;
    public Transform redMinionSpawnPos;

    //Prefabs
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject meleMinionPrefab;
    public GameObject rangedMinionPrefab;

    //Game objects
    GameObject player;
    GameObject enemy;
    public List<GameObject> blueSideMinions;
    public List<GameObject> redSideMinions;

    //Config
    public int numOfMeleMinions = 3;
    public int numOfRangedMinions = 2;
    public float spawnDelayDuringVaweSpawn = 0.5f;
    public float minionVaweSpawnDelay = 10f;

    float timeOfLastMinionSpawn = 0;
    float timeOfLastVaweSpawn = 0;

    void Start()
    {
        SpawnPlayers();
    }

    void Update()
    {

        // !!! Problem sa spawnovanjem vise vawe-ova !!!

        if(Time.time >= timeOfLastVaweSpawn + minionVaweSpawnDelay || Time.time <= 5)
            SpawnMinionVawe();
    }

    public void SpawnPlayers()
    {
        player = Instantiate(playerPrefab, playerSpawnPos.position + Vector3.up, Quaternion.identity);
        enemy = Instantiate(enemyPrefab, enemySpawnPos.position + Vector3.up, Quaternion.identity);

    }
    public void SpawnMinionVawe()
    {
        if (Time.time >= timeOfLastMinionSpawn + spawnDelayDuringVaweSpawn)
        {
            timeOfLastMinionSpawn = Time.time;

            //Spawnuj mele ili ranged minione
            if (blueSideMinions.Count < numOfMeleMinions + numOfRangedMinions)
            {
                if (blueSideMinions.Count < numOfMeleMinions && redSideMinions.Count < numOfMeleMinions)
                {
                    blueSideMinions.Add(Instantiate(meleMinionPrefab, blueMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity));
                    redSideMinions.Add(Instantiate(meleMinionPrefab, redMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity));
                }
                else
                {
                    blueSideMinions.Add(Instantiate(rangedMinionPrefab, blueMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity));
                    redSideMinions.Add(Instantiate(rangedMinionPrefab, redMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity));
                }
            }
            else if(blueSideMinions.Count == numOfMeleMinions + numOfRangedMinions)
            {
                timeOfLastVaweSpawn = Time.time;

                //Klirovanje liste nije pomoglo u problemu samo jednog vawe-a
                //blueSideMinions.Clear();
                //redSideMinions.Clear();
            }
        }
    }
}
