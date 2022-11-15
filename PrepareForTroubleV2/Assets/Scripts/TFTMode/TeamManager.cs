using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<PokemonController> myTeam = new List<PokemonController>();
    public List<PokemonController> enemyTeam = new List<PokemonController>(); 
    
    public void SetTeams(PlayerControllerTraining enemy)
    {
        foreach (PokemonController pokemon in this.GetComponent<PlayerControllerTraining>().myTeam)
        {
           myTeam.Add(pokemon);
        }

        foreach (PokemonController pokemon in enemy.myTeam)
        {
            enemyTeam.Add(pokemon);
        }
    }

    public void RemoveOnMyTeam(PokemonController pokemonToRemove)
    {
        foreach (PokemonController pokemon in myTeam)
        {
            myTeam.Remove(pokemonToRemove);
        }
    }
}
