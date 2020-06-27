using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Genome : MonoBehaviour
{

    // Trait Class simply corresponds to the loot pool for each of our creature types. ( for example, red genome pool = r, blue genome pool = b ect... )
    public char traitClass;
    public int gen;


    public Genome()
    {

    }

    public Genome(int round, char traitClass)
    {
        this.traitClass = traitClass;
        if (round == 2)
            gen = 1;
        if (round == 4)
            gen = 2;
        if (round == 6)
            gen = 3;
    }

}
