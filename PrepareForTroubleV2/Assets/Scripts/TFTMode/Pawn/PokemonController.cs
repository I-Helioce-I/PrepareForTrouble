using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Rank
{
    Rank1,
    Rank2,
    Rank3
}
public enum Rarity
{
    Grey,
    Green,
    Blue,
    Purple,
    Gold
}
public enum Type
{
    Normal,
    Water,
    Fire,
    Insect,
    Grass
}
public class PokemonController : MonoBehaviour
{
    public Rarity rarity;
    public Type type;
    public Rank rank;

    public int iD;
    public int goldCost;
    public PokemonStatsTraining stats;


    void Start()
    {

    }

}
