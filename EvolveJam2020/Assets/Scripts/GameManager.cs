using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region GENERAL VARIABLES

    public static GameManager instance = null;

    /// <summary>
    /// Pickups reference this to get color
    /// </summary>
    public Sprite[] pickupSprites;

    //public RuntimeAnimatorController[] pickupAnimations;

    [SerializeField]
    private GameObject[] allGenomes;

    [SerializeField]
    private PlayerMove p1Script, p2Script;

    [Header("If this many genomes are destroyed, the game ends")]
    [SerializeField]
    private int destroyedThreshold;

    /// <summary>
    /// Where Genomes will spawn from
    /// </summary>
    [SerializeField]
    private GameObject[] spawnPoints;

    /// <summary>
    /// Where enemies spawn from
    /// </summary>
    [SerializeField]
    private GameObject[] enemySpawnPoints;

    /// <summary>
    /// Which spawn points are occupied currently
    /// </summary>
    public bool[] occupiedSpawns;

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

    [SerializeField]
    private GameObject pausePanel;

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
    public float enemySpeed = 0.35f;

    /// <summary>
    /// The maximum speed an enemy can move
    /// </summary>
    private static float enemySpeedCap = 0.8f;

    /// <summary>
    /// How much the enemy's speed increases each level up
    /// </summary>
    private static float enemySpeedIncrement = 0.01f;



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
    private static float genomeGrabTimeIncrement = 0.05f;

    #endregion

    #region DYNAMIC VARIABLES

    private float currentSpawnDelay;

    public int enemiesKilled;

    public float timeSurvived;

    [HideInInspector]
    public bool inGame;

    #endregion

    #region UI OBJECTS

    [SerializeField]
    private TextMeshProUGUI timerText, genomesRemainingText;

    public GameObject[] waterIcons, earthIcons, fireIcons, airIcons;

    [HideInInspector]
    public GameObject selectedWaterIcon, selectedEarthIcon, selectedFireIcon, selectedAirIcon;

    public GameObject[] iconSlots;

    #endregion


    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);

        instance = this;

        pausePanel.SetActive(false);

        StartGame();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            // Keep track of how long you've survived
            timeSurvived += Time.deltaTime;
            timerText.text = $"Time Survived: {Mathf.FloorToInt(timeSurvived / 60)}:{Mathf.FloorToInt(timeSurvived % 60).ToString("00")}";

            if (currentSpawnDelay > 0)
            {
                currentSpawnDelay -= Time.deltaTime;
                if (currentSpawnDelay <= 0)
                {
                    // Spawn things
                    SpawnStuff();

                    // Reset it
                    currentSpawnDelay = spawnDelay;
                }
            }
        }                
    }

    private void SpawnStuff()
    {
        // Pick which spawn points to spawn at
        // First get available spawn points
        List<int> availableSpawns = new List<int>();
        for (int i = 0; i < occupiedSpawns.Length; i++)
        {
            if (occupiedSpawns[i] == false)
            {
                availableSpawns.Add(i);
            }
        }

        // Pick how many genomes to spawn
        int howManyGenomes = Random.Range(1, (int)maxGenomeSpawn);

        howManyGenomes = Mathf.Clamp(howManyGenomes, 1, availableSpawns.Count);

        // Pick how many enemies to spawn
        int howManyEnemies = Random.Range(0, howManyGenomes+1);

        Debug.Log($"Spawning Info: {howManyEnemies} Enemies, {howManyGenomes} Genomes and {availableSpawns.Count} spawn points");

        // For each genome being spawned
        for (int i = 0; i < howManyGenomes; i++)
        {
            // Pick which type it is
            int newGenomeType = Random.Range(0, 4);

            // Pick a random available spawn
            int spawnID = availableSpawns[Random.Range(0, availableSpawns.Count)];

            // Spawn the Genome
            GameObject clone = Instantiate(allGenomes[newGenomeType], spawnPoints[spawnID].transform, false);
            clone.transform.localPosition = Vector2.zero;
            clone.GetComponent<Pickup>().SetUp(newGenomeType, spawnID);
            availableSpawns.Remove(spawnID);
            occupiedSpawns[spawnID] = true;
        }

        // For each enemy
        for (int i = 0; i < howManyEnemies; i++)
        {
            // Pick a random spawn
            int spawnID = Random.Range(0, enemySpawnPoints.Length);

            // Spawn the Enemy
            Instantiate(enemyObject, enemySpawnPoints[spawnID].transform, false);          
        }

        // Reset the spawn counter
        currentSpawnDelay = spawnDelay;
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

            // Show how many remaing
            genomesRemainingText.text = $"Genomes Remaining: {destroyedThreshold - destroyedGenomes}";

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
        int rand = Random.Range(0, waterPowers.Length);
        waterPower = waterPowers[rand];
        selectedWaterIcon = waterIcons[rand];
        selectedWaterIcon.SetActive(true);

        // Pick random Earth Ability
        rand = Random.Range(0, earthPowers.Length);
        earthPower = earthPowers[rand];
        selectedEarthIcon = earthIcons[rand];
        selectedEarthIcon.SetActive(true);

        // Pick random Fire Ability
        rand = Random.Range(0, firePowers.Length);
        firePower = firePowers[rand];
        selectedFireIcon = fireIcons[rand];
        selectedFireIcon.SetActive(true);

        // Pick random Air Ability
        rand = Random.Range(0, airPowers.Length);
        airPower = airPowers[rand];
        selectedAirIcon = airIcons[rand];
        selectedAirIcon.SetActive(true);

        // Keep track of the chosen power of each type
        chosenPowers = new List<string>() { waterPower, earthPower, firePower, airPower };

        // Assign these abilities to the players (we won't need this if we have 
        AssignAbilities();

        // Initialize the spawn delay
        currentSpawnDelay = spawnDelay;

        occupiedSpawns = new bool[8];

        for(int i = 0; i < occupiedSpawns.Length; i++)
        {
            occupiedSpawns[i] = false;
        }

        inGame = true;

        genomesRemainingText.text = $"Genomes Remaining: {destroyedThreshold - destroyedGenomes}";
    }

    public void NewAssignAbilities(PlayerMove script, int abilityNum, string ability)
    {
        if (abilityNum == 1)
        {
            script.a1 = GetAbility(ability);
        }
        else
        {
            script.a2 = GetAbility(ability);
        }
    }

    public string GetAbility(string type)
    {
        switch (type)
        {
            case "Water":
                return waterPower;
            case "Earth":
                return earthPower;
            case "Fire":
                return firePower;
            case "Air":
                return airPower;
            default:
                Debug.LogError("GetAbility not finding ability");
                return null;
        }
    }

    /// <summary>
    /// Adds the ability to a random player's arsenal (max of 2 per player)
    /// </summary>
    private void AssignAbilities()
    {
        // Pick 2 random abilities to give to each player        
        p1Script.a1 = GetRandomAbility(0);
        p1Script.a2 = GetRandomAbility(1);
        p2Script.a1 = GetRandomAbility(2);
        p2Script.a2 = GetRandomAbility(3);
    }

    /// <summary>
    /// Grab a random ability and return its name
    /// </summary>
    /// <returns></returns>
    private string GetRandomAbility(int iconSpot)
    {        
        int randIndex = Random.Range(0, chosenPowers.Count);
        string randPower = chosenPowers[randIndex];
        chosenPowers.RemoveAt(randIndex);

        GameObject.Find(randPower + "Icon").transform.position = iconSlots[iconSpot].transform.position;

        return randPower;
    }

    /// <summary>
    /// End the game, when a player hits a zombie or loses too many genomes
    /// </summary>
    public void EndGame()
    {
        Debug.Log("Game Over");
        inGame = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Return a player type
    /// </summary>
    /// <param name="number">Player number (1 for p1)</param>
    /// <returns>Player name</returns>
    public GameObject GetPlayer(int number)
    {
        if (number == 1)
        {
            return p1Script.gameObject;
        }
        return p2Script.gameObject;
    }
}
