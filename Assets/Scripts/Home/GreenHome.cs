using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHome : PlayerHome
{
    public void CheckingAtHome()
    {
        foreach (Transform child in this.transform)
        {
            bool home = false;
            for (int i = 0; i < 4; i++)
            {
                if (child.position == Home[i].position)
                {
                    home = true;
                }
            }
            child.gameObject.GetComponent<GreenMovement>().isReady = !home;
        }
    }
    public void deselectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<GreenMovement>() != null)
            {
                child.gameObject.GetComponent<GreenMovement>().canBeSelected = false;
            }
        }
    }

    public void selectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<GreenMovement>() != null)
            {
                child.gameObject.GetComponent<GreenMovement>().canBeSelected = true;
            }
        }
    }
    public void selectOnlyOustide()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<GreenMovement>() != null)
            {
                if (child.gameObject.GetComponent<GreenMovement>().isReady)
                {
                    child.gameObject.GetComponent<GreenMovement>().canBeSelected = true;
                }
                else
                {
                    child.gameObject.GetComponent<GreenMovement>().canBeSelected = false;
                }
            }
        }
    }
}
