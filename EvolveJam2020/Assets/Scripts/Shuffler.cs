using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Place on camera or empty game object

public class Shuffler : MonoBehaviour
{
    int players;
    [SerializeField] GameObject abilities;
    [SerializeField]  List<Element> elements = new List<Element> { Element.Fire, Element.Air, Element.Water, Element.Earth };
    private Stack<Element> randomized;
    // Start is called before the first frame update
    private void Awake()
    {
         randomized = new Stack<Element>();
        GameObject [] players = GameObject.FindGameObjectsWithTag("Player");
        var rand = new System.Random();
        elements = elements.OrderBy(x => rand.Next()).ToList();

        foreach (Element e in elements)
        {
            randomized.Push(e);
        }

        //Assign each player a random element by randomizing a stack of 4 and just pop off
        foreach (GameObject player in players)
        {
            ElementLoadout loadout = player.GetComponent<ElementLoadout>();
            loadout.m_Element = (Element)randomized.Pop();
            AssignPrimaryTrait(loadout.m_Element, player);
            AssignSecondaryTrait(loadout.m_Element, player);
        }

    }

    public void AssignPrimaryTrait(Element e, GameObject player)
    {
        
        ElementLoadout loadout = player.GetComponent<ElementLoadout>();
        Debug.Log("Assigning primarary trait for " + player.name + " of type " + loadout.m_Element);
        if (e == Element.Fire)
        {
            loadout.PrimaryTrait = new Trait("FireTraitPrimary");
        }
        if (e == Element.Water)
        {
            loadout.PrimaryTrait = new Trait("WaterTraitPrimary");
        }
        if (e == Element.Earth)
        {
            loadout.PrimaryTrait = new Trait("EarthTraitPrimary");
        }
        if (e == Element.Air)
        {
            loadout.PrimaryTrait = new Trait("AirTraitPrimary");
        }
        loadout.Primary = loadout.PrimaryTrait.name;
    }

    public void AssignSecondaryTrait(Element e, GameObject player)
    {
        Debug.Log("Assigning secondary trait for " + player.name);
        ElementLoadout loadout = player.GetComponent<ElementLoadout>();
        if (e == Element.Fire)
        {
            loadout.SecondaryTrait = new Trait("FireTraitSecondary");
        }
        if (e == Element.Water)
        {
            loadout.SecondaryTrait = new Trait("WaterTraitSecondary");
        }
        if (e == Element.Earth)
        {
            loadout.SecondaryTrait = new Trait("EarthTraitSecondary");
        }
        if (e == Element.Air)
        {
            loadout.SecondaryTrait = new Trait("AirTraitSecondary");
        }
        loadout.Secondary = loadout.SecondaryTrait.name;
    }

}
