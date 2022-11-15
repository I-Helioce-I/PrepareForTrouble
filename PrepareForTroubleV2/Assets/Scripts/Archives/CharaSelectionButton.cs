using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class CharaSelectionButton : MonoBehaviourPun
{
    public string pokemonName;
    public Sprite image;

    public void Start()
    {
        GetComponent<Image>().sprite = image;
    }

}
