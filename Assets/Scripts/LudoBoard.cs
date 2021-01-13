using System.Collections;
using UnityEngine;

public class LudoBoard : MonoBehaviour
{
    public int numberGot;
    public bool diceRoll;
    public string[] tags = { "blue", "red"  , "green", "yellow" };
    public int NumberOfPlayers;
    public int whoseChance = 0;
    public DiceRoll dr;
    public PlayerHome[] AllLudoHomes;
    // 0 B, 1 R, 2 G ,3 Y 

    public static LudoBoard lb;
    private void Awake()
    {
        lb = this;
        diceRoll = true;
        NumberOfPlayers = 4;
    }

    int i = 0;
    private void Update()
    {
        whoseChance = whoseChance / NumberOfPlayers;
        whoseChance++;
    }

    public void Chance()
    {
        if (diceRoll)
        {

        }
    }

}
