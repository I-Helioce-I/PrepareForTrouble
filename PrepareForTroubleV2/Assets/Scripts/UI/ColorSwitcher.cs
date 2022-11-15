using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{

    public MeshRenderer actual;
    public Material def;
    public Material selected;

    public void SetDef()
    {
        actual.material = def;
    }

    public void SetSelected()
    {
        actual.material = selected;
    }
}
