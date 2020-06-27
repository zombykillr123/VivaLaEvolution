using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    // Going to keep track of player evolution

    int gameRound;
    GameObject[] savedCreatures;

    [SerializeField]  string[] traitLoadout = new string[3];

    [HideInInspector] public Genome[] playerGenomes = new Genome[3]; // size 3 because we plan to let the player evolve 3 times per game

    public Genome Evolve()
    {
        Debug.Log(this.name + " Is Evolving!");
        Genome gene = Inherit();
        traitLoadout[gameRound] = gene.name;
        return gene;
    }

    private Genome Inherit()
    {
        //not implemented
        return new Gen1R1();
    }
}
