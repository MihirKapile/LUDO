using UnityEngine;

public class BlueHome : PlayerHome
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
            child.gameObject.GetComponent<BlueMovement>().isReady = !home;
        }
    }
    public void deselectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<BlueMovement>() != null)
            {
                child.gameObject.GetComponent<BlueMovement>().canBeSelected = false;
            }
        }
    }

    public void selectAll()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<BlueMovement>() != null)
            {
                child.gameObject.GetComponent<BlueMovement>().canBeSelected = true;
            }
        }
    }
    public void selectOnlyOustide()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<BlueMovement>() != null)
            {
                if (child.gameObject.GetComponent<BlueMovement>().isReady)
                {
                    child.gameObject.GetComponent<BlueMovement>().canBeSelected = true;
                }
                else
                {
                    child.gameObject.GetComponent<BlueMovement>().canBeSelected = false;
                }
            }
        }
    }
}
