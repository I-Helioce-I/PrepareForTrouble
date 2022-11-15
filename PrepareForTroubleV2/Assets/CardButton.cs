using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CardButton : MonoBehaviourPun
{
    public TextMeshProUGUI pokemonName;
    public Image pokemonImage;

    public void DisplayCard(CardButton cardToInsert)
    {
        pokemonName = cardToInsert.pokemonName;
        pokemonImage = cardToInsert.pokemonImage;

    }


    
}
