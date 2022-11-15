using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTraining : MonoBehaviour
{
    public int playerLife;
    public PokemonController[] myTeam;

    public List<GameObject> myTerrain;

    public Camera currentCamera;

    public GameManagerTraining gMT;

    public Transform[] spawn;

    public GameObject currentHover;

    // Start is called before the first frame update
    void Start()
    {
        gMT.tMT.GenerateAllTiles(this, spawn);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out info, 200))
        {

            GameObject actualHit = info.collider.gameObject;

            if(currentHover == null)
            {
                if(actualHit.layer == LayerMask.NameToLayer("MyTile"))
                {
                    actualHit.layer = LayerMask.NameToLayer("Hover");
                    actualHit.GetComponent<ColorSwitcher>().SetSelected();
                    currentHover = actualHit;
                }
                else
                {
                    currentHover = actualHit;
                }
            }
            else
            {
                if(currentHover == actualHit)
                {
                    return;
                }
                else
                {
                    
                    if (currentHover.layer == LayerMask.NameToLayer("Hover"))
                    {
                        currentHover.layer = LayerMask.NameToLayer("MyTile");
                        currentHover.GetComponent<ColorSwitcher>().SetDef();
                        currentHover = actualHit;
                    }
                    else
                    {
                        if (actualHit.layer == LayerMask.NameToLayer("MyTile"))
                        {
                            actualHit.layer = LayerMask.NameToLayer("Hover");
                            actualHit.GetComponent<ColorSwitcher>().SetSelected();
                            currentHover = actualHit;
                        }
                        else
                        {

                        }
                    }
                }

                
            }


            //if(currentHover == null)
            //{
            //    currentHover = actualHit;

            //    if(currentHover.layer == LayerMask.NameToLayer("MyTile"))
            //    {
            //        actualHit.gameObject.layer = LayerMask.NameToLayer("Hover");
            //        actualHit.GetComponent<ColorSwitcher>().SetSelected();
            //    }

            //}

            //if(currentHover != null && currentHover != actualHit)
            //{
            //    if (currentHover.layer == LayerMask.NameToLayer("Hover"))
            //    {
            //        currentHover.layer = LayerMask.NameToLayer("MyTile");
            //        actualHit.GetComponent<ColorSwitcher>().SetDef();
            //        currentHover = actualHit;
            //        currentHover.layer = LayerMask.NameToLayer("Hover");
            //        actualHit.GetComponent<ColorSwitcher>().SetSelected();
            //    }

            //    if (currentHover.layer == LayerMask.NameToLayer("MyTile"))
            //    {
            //        currentHover.layer = LayerMask.NameToLayer("Hover");
            //        actualHit.GetComponent<ColorSwitcher>().SetSelected();
            //        currentHover = actualHit;
            //    }


            //}
            //else
            //{
            //    //if (currentHover.layer == LayerMask.NameToLayer("Hover"))
            //    //{
            //    //    currentHover.layer = LayerMask.NameToLayer("MyTile");
            //    //    actualHit.GetComponent<ColorSwitcher>().SetDef();
            //    //    currentHover = actualHit;
            //    //}
            //}

            
        }



    }

    

    public void SetPlacement()
    {
        
    }
}
