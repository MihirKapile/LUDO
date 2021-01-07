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
            child.gameObject.GetComponent<BlueMovement>().atHome = home;
        }
    }
}
