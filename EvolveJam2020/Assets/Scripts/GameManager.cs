using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region GENERAL VARIABLES

    public static GameManager instance = null;

    /// <summary>
    /// Pickups reference this to get color
    /// </summary>
    public Sprite[] pickupSprites;
    
    public AnimatorController[] pickupAnimations;

    [SerializeField]
    private PlayerMove p1Script, p2Script;

    [Header("If this many genomes are destroyed, the game ends")]
    [SerializeField]
    private int destroyedThreshold;

    /// <summary>
    /// Where Genomes/Enemies will spawn from
    /// </summary>
    [SerializeField]
    private GameObject[] spawnPoints;

    /// <summary>
    /// How many have been destroyed so far
    /// </summary>
    private int destroyedGenomes;

    /// <summary>
    /// The Genome Fairy Object to be spawned
    /// </summary>
    [SerializeField]
    private GameObject genomeObject;

    /// <summary>
    /// The Enemy Object to be spawned
    /// </summary>
    [SerializeField]
    private GameObject enemyObject;

    #endregion

    #region POWER VARIABLES

    /// <summary>
    /// All pickups in the level
    /// </summary>
    public GameObject[] allPickups;

    public string[] waterPowers, earthPowers, firePowers, airPowers;

    public int waterLevel, earthLevel, fireLevel, airLevel;

    private string waterPower, earthPower, firePower, airPower;

    private List<string> chosenPowers;

    #endregion

    #region SCALING VARAIBLES

    /// <summary>
    /// How long in seconds between spawn chunks (decreases as you evolve)
    /// </summary>
    private float spawnDelay = 5f;

    /// <summary>
    /// The minimum time between spawns
    /// </summary>
    private static float spawnDelayCap = 2f;

    /// <summary>
    /// How much the delay shrinks by each level up
    /// </summary>
    private static float spawnDelayIncrement = 0.025f;



    /// <summary>
    /// How many Genomes spawn, enemies spawn between 1 and this number (increases as you level up)
    /// </summary>
    private float maxGenomeSpawn = 1;

    /// <summary>
    /// The max genome that can spawn (it's a float that rounds up as you level up)
    /// </summary>
    private static float maxGenomeSpawnCap = 5f;

    /// <summary>
    /// How much the spawn number increases each evolve
    /// </summary>
    private static float maxGenomeSpawnIncrement = 0.05f;



    /// <summary>
    /// How fast enemies move (increases as you level up)
    /// </summary>
    private float enemySpeed = 0.3f;

    /// <summary>
    /// The maximum speed an enemy can move
    /// </summary>
    private static float enemySpeedCap = 0.8f;

    /// <summary>
    /// How much the enemy's speed increases each level up
    /// </summary>
    private static float enemySpeedIncrement = 0.005f;



    /// <summary>
    /// How long it takes to grab a genome of this type (in seconds)
    /// </summary>
    private float waterGrab, fireGrab, airGrab, earthGrab;

    /// <summary>
    /// Max time it takes to grab a genome (in seconds)
    /// </summary>
    private static float genomeGrabMaxTime = 10f;

    /// <summary>
    /// How much the time to grab a genome increases each level up
    /// </summary>
    private static float genomeGrabTimeIncrement = 0.01f;

    #endregion

    #region DYNAMIC VARIABLES

    private float currentSpawnDelay;

    #endregion


    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;        

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnDelay > 0)
        {
            currentSpawnDelay -= Time.deltaTime;
            if (currentSpawnDelay < spawnDelay)
            {
                // Spawn things
                SpawnStuff();

                // Reset it
                currentSpawnDelay = spawnDelay;
            }
        }
    }

    private void SpawnStuff()
    {
        // Pick how many genomes to spawn
        int howManyGenomes = Random.Range(0, (int)maxGenomeSpawn);

        // Pick how many enemies to spawn
        int howManyEnemies = Random.Range(0, howManyGenomes);

        // Pick which spawn points to spawn at

        // For each genome

        // Pick which type it is

        // Spawn the Genome

        // For each enemy

        // Spawn the enemy
    }

    /// <summary>
    /// Addps pickups you grab to the list
    /// </summary>
    /// <param name="pickupType">The pickups number</param>
    /// <param name="destroyed">Set true if an enemy touched it</param>
    public void LosePickup(int pickupType, bool destroyed)
    {
        if (!destroyed)
        {
            // Increase the level of this power
            LevelUp(pickupType);
        }
        else
        {
            // Increment destroyed pickups
            destroyedGenomes++;

            // If this number is too high, end the game
            if (destroyedGenomes >= destroyedThreshold)
            {
                // End the game
                EndGame();
            }
        }
    }

    /// <summary>
    /// Level up one of the types
    /// </summary>
    /// <param name="type">The type to level up</param>
    private void LevelUp(int type)
    {
        // Increase level and time to grab that element
        switch (type)
        {
            case 0:
                // Water
                waterLevel++;
                IncreaseGenomeGrabTime(waterGrab);
                break;
            case 1:
                // Fire
                fireLevel++;
                IncreaseGenomeGrabTime(fireGrab);
                break;
            case 2:
                // Air
                airLevel++;
                IncreaseGenomeGrabTime(airGrab);
                break;
            case 3:
                // Earth
                earthLevel++;
                IncreaseGenomeGrabTime(earthGrab);
                break;
            default:
                Debug.LogError("Type not set on this powerup");
                break;
        }

        // Slightly increase enemy move speed
        if (enemySpeed < enemySpeedCap)
        {
            enemySpeed += enemySpeedIncrement;
            if (enemySpeed > enemySpeedCap)
            {
                enemySpeed = enemySpeedCap;
            }
        }
              
        // Slightly decrease time between spawns
        if (spawnDelay > spawnDelayCap)
        {
            spawnDelay -= spawnDelayIncrement;
            if (spawnDelay <= spawnDelayCap)
            {
                spawnDelay = spawnDelayCap;
            }
        }

        // This will round up, so it will take 10 to reach the next number
        if (maxGenomeSpawn < maxGenomeSpawnCap)
        {
            maxGenomeSpawn += maxGenomeSpawnIncrement;
            if (maxGenomeSpawn > maxGenomeSpawnCap)
            {
                maxGenomeSpawn = maxGenomeSpawnCap;
            }
        }
    }

    /// <summary>
    /// Increase the time to grab a genome
    /// </summary>
    /// <param name="currentTime">Current pickup time for that type</param>
    /// <returns>A new time</returns>
    private float IncreaseGenomeGrabTime(float currentTime)
    {
        if (currentTime < maxGenomeSpawn)
        {
            currentTime += genomeGrabTimeIncrement;
            if (currentTime >= genomeGrabMaxTime)
            {
                currentTime = genomeGrabMaxTime;
            }
        }
        return currentTime;
    }

    /// <summary>
    /// Sets up the game
    /// </summary>
    public void StartGame()
    {
        // Generate abilities for that game

        // Pick random Water Ability
        waterPower = waterPowers[Random.Range(0, waterPowers.Length)];        

        // Pick random Earth Ability
        earthPower = earthPowers[Random.Range(0, earthPowers.Length)];

        // Pick random Fire Ability
        firePower = firePowers[Random.Range(0, firePowers.Length)];

        // Pick random Air Ability
        airPower = airPowers[Random.Range(0, airPowers.Length)];

        // Keep track of the chosen power of each type
        chosenPowers = new List<string>() { waterPower, earthPower, firePower, airPower };

        // Assign these abilities to the players (we won't need this if we have 
        AssignAbilities();

        // Initialize the spawn delay
        currentSpawnDelay = spawnDelay;
    }

    /// <summary>
    /// Adds the ability to a random player's arsenal (max of 2 per player)
    /// </summary>
    private void AssignAbilities()
    {
        // Pick 2 random abilities to give to each player

        p1Script.a1 = GetRandomAbility();
        p1Script.a2 = GetRandomAbility();
        p2Script.a1 = GetRandomAbility();
        p2Script.a2 = GetRandomAbility();
    }

    /// <summary>
    /// Grab a random ability and return its name
    /// </summary>
    /// <returns></returns>
    private string GetRandomAbility()
    {        
        int randIndex = Random.Range(0, chosenPowers.Count);
        string randPower = chosenPowers[randIndex];
        chosenPowers.RemoveAt(randIndex);

        return randPower;
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public GameObject GetPlayer(int number)
    {
        if (number == 1)
        {
            return p1Script.gameObject;
        }
        return p2Script.gameObject;
    }
}
