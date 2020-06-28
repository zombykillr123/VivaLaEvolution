using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    /// <summary>
    /// Pickups you own
    /// </summary>
    public List<int> ownedPickups;

    /// <summary>
    /// Number of pickups still in this level
    /// </summary>
    private int remainingPickups;

    /// <summary>
    /// Pickups reference this to get color
    /// </summary>
    public Sprite[] pickupSprites;

    public AnimatorController[] pickupAnimations;

    /// <summary>
    /// All pickups in the level
    /// </summary>
    public GameObject[] allPickups;

    public string[] waterPowers, earthPowers, firePowers, airPowers;

    public int waterLevel, earthLevel, fireLevel, airLevel;

    private string waterPower, earthPower, firePower, airPower;

    [SerializeField]
    private PlayerMove p1Script, p2Script;

    private List<string> chosenPowers;

    [Header("If this many genomes are destroyed, the game ends")]
    [SerializeField]
    private int destroyedThreshold;

    /// <summary>
    /// How many have been destroyed so far
    /// </summary>
    [HideInInspector]
    public int destroyedGenomes;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;        

        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }

    private void LevelUp(int type)
    {
        switch (type)
        {
            case 0:
                // Water
                waterLevel++;
                break;
            case 1:
                // Fire
                fireLevel++;
                break;
            case 2:
                // Air
                airLevel++;
                break;
            case 3:
                // Earth
                earthLevel++;
                break;
            default:
                Debug.LogError("Type not set on this powerup");
                break;
        }
    }

    /// <summary>
    /// Sets the number of pickups in the level. When it reaches 0 it does something
    /// </summary>
    public void StartLevel()
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

    public void RetartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
