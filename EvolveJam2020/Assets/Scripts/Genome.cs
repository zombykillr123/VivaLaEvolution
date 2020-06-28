using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public abstract class Genome : MonoBehaviour
{

    // Trait Class simply corresponds to the ability pool for each of our creature types. ( for example, red genome pool = r, blue genome pool = b ect... )
    int PlayerCount;
    [SerializeField] static List<Element> elements = new List<Element> { Element.Fire, Element.Air, Element.Water, Element.Earth };
    static Stack<Element> assignmentStack;
    public new string name;

    private static void Awake()
    { 

    }



}
