using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class TurnTrainingChoice : MonoBehaviourPun
{

    public List<Button> button;

    [PunRPC]
    public void SetUpCard(CardButton cardButton, Button button)
    {
        button.GetComponent<CardButton>().DisplayCard(cardButton);
    }



}
