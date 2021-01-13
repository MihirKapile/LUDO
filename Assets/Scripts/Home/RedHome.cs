using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHome : PlayerHome
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
            child.gameObject.GetComponent<RedMovement>().isReady = !home;
        }
    }
    public void deselectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<RedMovement>() != null)
            {
                child.gameObject.GetComponent<RedMovement>().canBeSelected = false;
            }
        }
    }

    public void selectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<RedMovement>() != null)
            {
                child.gameObject.GetComponent<RedMovement>().canBeSelected = true;
            }
        }
    }
    public void selectOnlyOustide()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<RedMovement>() != null)
            {
                if (child.gameObject.GetComponent<RedMovement>().isReady)
                {
                    child.gameObject.GetComponent<RedMovement>().canBeSelected = true;
                }
                else
                {
                    child.gameObject.GetComponent<RedMovement>().canBeSelected = false;

                }
            }
        }
    }
}

