using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovement : PlayerMovement
{

    public int[] blueIndex;
    public int currentPos = 0;
    private void Start()
    {
        blueIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 52, 53, 54, 55, 56, 57 };

    }
    private void Update()
    {
        SelectingPiece();
        Selection();
    }
    private void OnMouseDown()
    {
        //whenGotSix();
        if (atHome)
        {
            canBeSelected = false;
        }

        if (canBeSelected)
        {
            atHome = false;
        }


        if (!atHome)
        {
            int r = lb.numberGot+1;
            StartCoroutine(MovePiece(blueIndex, currentPos, r));
            currentPos += r;
        }
 
    }

}
