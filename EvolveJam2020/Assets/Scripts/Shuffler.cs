using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Place on camera or empty game object

public class Shuffler : MonoBehaviour
{
    int players;
    [SerializeField]  List<Element> elements = new List<Element> { Element.Fire, Element.Air, Element.Water, Element.Earth };
    private Stack<Element> randomized;

    [SerializeField]
    private GameObject[] playerList;

    // Start is called before the first frame update
    private void Awake()
    {
        randomized = new Stack<Element>();
        //GameObject [] players = GameObject.FindGameObjectsWithTag("Player");
        var rand = new System.Random();
        elements = elements.OrderBy(x => rand.Next()).ToList();

        foreach (Element e in elements)
        {
            randomized.Push(e);
        }

        //Assign each player a random element by randomizing a stack of 4 and just pop off
        foreach (GameObject player in playerList)
        {
            ElementLoadout loadout = player.GetComponent<ElementLoadout>();
            loadout.m_Element = (Element)randomized.Pop();
            AssignPrimaryTrait(loadout.m_Element, player);

            loadout.m_Element = (Element)randomized.Pop();
            AssignSecondaryTrait(loadout.m_Element, player);
        }

    }

    public void AssignPrimaryTrait(Element e, GameObject player)
    {        
        ElementLoadout loadout = player.GetComponent<ElementLoadout>();
        //Debug.Log("Assigning primarary trait for " + player.name + " of type " + loadout.m_Element);        

        string ability = null;

        if (e == Element.Fire)
        {
            loadout.PrimaryTrait = new Trait("FireTraitPrimary");
            ability = "Fire";
        }
        if (e == Element.Water)
        {
            loadout.PrimaryTrait = new Trait("WaterTraitPrimary");
            ability = "Water";
        }
        if (e == Element.Earth)
        {
            loadout.PrimaryTrait = new Trait("EarthTraitPrimary");
            ability = "Earth";
        }
        if (e == Element.Air)
        {
            loadout.PrimaryTrait = new Trait("AirTraitPrimary");
            ability = "Air";
        }
        loadout.Primary = loadout.PrimaryTrait.name;

        Debug.Log($"Primary trait for {player.name} is {loadout.PrimaryTrait.name}");

        //GameManager.instance.NewAssignAbilities(player.GetComponent<PlayerMove>(), 1, ability);
    }

    public void AssignSecondaryTrait(Element e, GameObject player)
    {
        
        ElementLoadout loadout = player.GetComponent<ElementLoadout>();
        //Debug.Log("Assigning secondary trait for " + player.name + " of type " + loadout.m_Element);

        string ability = null;

        if (e == Element.Fire)
        {
            loadout.SecondaryTrait = new Trait("FireTraitSecondary");
            ability = "Fire";
        }
        if (e == Element.Water)
        {
            loadout.SecondaryTrait = new Trait("WaterTraitSecondary");
            ability = "Water";
        }
        if (e == Element.Earth)
        {
            loadout.SecondaryTrait = new Trait("EarthTraitSecondary");
            ability = "Earth";
        }
        if (e == Element.Air)
        {
            loadout.SecondaryTrait = new Trait("AirTraitSecondary");
            ability = "Air";
        }
        loadout.Secondary = loadout.SecondaryTrait.name;
        
        Debug.Log($"Secondary trait for {player.name} is {loadout.SecondaryTrait.name}");

        //GameManager.instance.NewAssignAbilities(player.GetComponent<PlayerMove>(), 2, ability);
    }

}
