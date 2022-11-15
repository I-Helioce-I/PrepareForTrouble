using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn_Stats", menuName = "ScriptableObjects/Pawn_Stats")]
public class PokemonStatsTraining : ScriptableObject
{
    public float maxHealth;

    public float attack;
    public float defense;
    public float attackSpecial;
    public float defenseSpecial;

    public float speed;

    public float multiplier;

}
