using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Fire , Water , Earth, Air
}


public class ElementLoadout : MonoBehaviour
{
    // Going to keep track of player evolution
    // cast integer into the enum
    // instance on each player. This is initialized to one fo the four elements at start

    [SerializeField] private int m_EvolutionPoints = 0;
    [SerializeField] public Element m_Element;

    int gameRound;
    GameObject[] savedCreatures;
}
