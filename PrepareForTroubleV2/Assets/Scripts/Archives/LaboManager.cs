using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboManager : MonoBehaviour
{
    public CampManager[] campManagers;
    // Start is called before the first frame update
    void Start()
    {
        foreach(CampManager cM in campManagers)
        {
            cM.TriggerCamp();
        }
    }

}
