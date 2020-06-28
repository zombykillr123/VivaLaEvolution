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
            player.GetComponent<ElementLoadout>().m_Element = (Element) randomized.Pop();
        }

    }
}
