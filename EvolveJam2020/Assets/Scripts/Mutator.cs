using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    // Going to keep track of player evolution

    protected int evolution;
    int gameRound;

    public static Genome Evolve()
    {
        return new Gen1R1();
    }

}
