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

    //Player/Minion Materials
    public Material blueMeleMaterial;
    public Material blueRangedMaterial;
    public Material redMeleMaterial;
    public Material redRangedMaterial;

    void Start()
    {
        SpawnPlayers();
    }

    void Update()
    {
        //Handle Spawning Minion Vawes
        if (Time.time >= timeOfLastVaweSpawn + minionVaweSpawnDelay || Time.time < 5)
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
                    //Blue side
                    GameObject blue = Instantiate(meleMinionPrefab, blueMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity);
                    //blue.GetComponent<Renderer>().material = blueMeleMaterial;
                    blue.tag = "BlueSide";
                    blue.GetComponent<MinionMovement>().enemyTeamTag = "RedSide";

                    blueSideMinions.Add(blue);

                    //Red side
                    GameObject red = Instantiate(meleMinionPrefab, redMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity);
                    //red.GetComponent<Renderer>().material = redMeleMaterial;
                    red.tag = "RedSide";
                    red.GetComponent<MinionMovement>().enemyTeamTag = "BlueSide";

                    redSideMinions.Add(red);
                }
                else
                {
                    //Blue side
                    GameObject blue = Instantiate(rangedMinionPrefab, blueMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity);
                    blue.GetComponent<Renderer>().material = blueRangedMaterial;
                    blue.tag = "BlueSide";
                    blue.GetComponent<MinionMovement>().enemyTeamTag = "RedSide";

                    blueSideMinions.Add(blue);

                    //Red side
                    GameObject red = Instantiate(rangedMinionPrefab, redMinionSpawnPos.position + Vector3.up / 2, Quaternion.identity);
                    red.GetComponent<Renderer>().material = redRangedMaterial;
                    red.tag = "RedSide";
                    red.GetComponent<MinionMovement>().enemyTeamTag = "BlueSide";

                    redSideMinions.Add(red);
                }
            }
            else if (blueSideMinions.Count == numOfMeleMinions + numOfRangedMinions)
            {
                timeOfLastVaweSpawn = Time.time;

                blueSideMinions.Clear();
                redSideMinions.Clear();
            }
        }
    }
}
