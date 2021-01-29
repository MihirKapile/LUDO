using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerHome : MonoBehaviour
{
    public Transform[] Home;
    public GameObject prefab_piece;
    public DiceRoll dr;
    public GameObject[] childPieces = new GameObject[4];
    public void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            Vector2 tempPos = Home[i].position;
            GameObject piece_child = Instantiate(prefab_piece, tempPos, Quaternion.identity);
            piece_child.transform.parent = this.transform;
            piece_child.name = i.ToString();
            piece_child.GetComponent<PlayerMovement>().playerSpecificHome = Home[i];
            childPieces[i] = piece_child;
        }
    }

    public bool checkAllatHome()
    {
        for (int i = 0; i < 4; i++)
        {
            if(childPieces[i].transform != Home[i])
            {
                return false;
            }
        }

        return true;
    }



}
