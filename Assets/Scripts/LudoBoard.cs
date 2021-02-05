using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudoBoard : MonoBehaviour
{
    public int numberGot;
    public bool diceRoll;
    //public bool chanceDone;
    public string[] tags = { "blue", "red", "green", "yellow" };
    public int NumberOfPlayers;
    public List<PlayerHome> CurrentHomes = new List<PlayerHome>();
    public int whoseChance=0;
    public DiceRoll dr;
    public PlayerHome[] AllLudoHomes;
    // 0 B, 1 R, 2 G ,3 Y 
    Coroutine chance_co;
    public static LudoBoard lb;
    private void Awake()
    {
        lb = this;
        diceRoll = true;
        //chanceDone = true;
        //NumberOfPlayers = 4;
        SetPlayers(NumberOfPlayers);
        StartCoroutine(nextChance_enum());
    }


    void SetPlayers(int players_)
    {
        for (int i = 0; i < 4; i++)
        {
            AllLudoHomes[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < players_; i++)
        {
            AllLudoHomes[i].gameObject.SetActive(true);
            CurrentHomes.Add(AllLudoHomes[i]);
        }

    }


    private void Update()
    {
        //if (chanceDone)
        //{
            //chance_co = StartCoroutine(Chance_enum());
        //}
    }
    public IEnumerator OneMoreChance_enum()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < NumberOfPlayers; i++)
        {
            if (i != whoseChance)
            {
                CurrentHomes[i].gameObject.transform.GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                CurrentHomes[i].gameObject.transform.GetChild(4).gameObject.SetActive(false);

            }
        }
        diceRoll = true;
    }
    public IEnumerator nextChance_enum()
    {
        if (diceRoll)
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
               if(i != whoseChance)
                {
                    CurrentHomes[i].gameObject.transform.GetChild(4).gameObject.SetActive(false);
                }
                else
                {
                    CurrentHomes[i].gameObject.transform.GetChild(4).gameObject.SetActive(true);

                }
            }
            yield return new WaitForSeconds(1.5f);
            whoseChance += 1;
            whoseChance %= LudoBoard.lb.NumberOfPlayers;
            diceRoll = true;
            //diceRoll = false;
        }
    }

}
