using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    None = 0,
    Cac = 1,
    Ranged = 2
}

public class PokemonMovementControllerTraining : MonoBehaviour
{
    public MovementType movementType;

    public void Update()
    {
        if(movementType == MovementType.None)
        {
            return;
        }

        if (movementType == MovementType.Cac)
        {
            MovementCaC();
        }

        if (movementType == MovementType.Ranged)
        {
            MovementRanged();
        }

    }

    private void MovementCaC()
    {

    }

    private void MovementRanged()
    {

    }
}
