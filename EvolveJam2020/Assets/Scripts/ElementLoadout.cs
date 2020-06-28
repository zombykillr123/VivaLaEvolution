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
    [SerializeField] public string Primary;
    [SerializeField] public string Secondary;
    public Trait PrimaryTrait;
    public Trait SecondaryTrait;
    
    int gameRound;

    private void Awake()
    {
        if (PrimaryTrait == null && SecondaryTrait == null)
            Debug.Log("Please make sure shuffler.cs is in the scene somewhere!");
    }

}
