using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowHome : PlayerHome
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
            child.gameObject.GetComponent<YellowMovement>().isReady = !home;
        }
    }
    public void deselectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<YellowMovement>() != null)
            {
                child.gameObject.GetComponent<YellowMovement>().canBeSelected = false;
            }
        }
    }

    public void selectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<YellowMovement>() != null)
            {
                child.gameObject.GetComponent<YellowMovement>().canBeSelected = true;
            }
        }
    }
    public void selectOnlyOustide()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<YellowMovement>() != null)
            {
                if (child.gameObject.GetComponent<YellowMovement>().isReady)
                {
                    child.gameObject.GetComponent<YellowMovement>().canBeSelected = true;
                }
                else
                {
                    child.gameObject.GetComponent<YellowMovement>().canBeSelected = false;
                }
            }
        }
    }
}
