using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
