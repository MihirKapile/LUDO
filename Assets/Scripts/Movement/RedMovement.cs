using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMovement : PlayerMovement
{
    public int[] redIndex;
    public int currentPos = 0;
    private void Start()
    {
        redIndex = new int[] { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51,0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 58, 59, 60, 61, 62, 63 };

    }
    private void OnMouseDown()
    {
        int r = lb.numberGot;

        StartCoroutine(MovePiece(redIndex, currentPos, r));
        currentPos += r;


    }

}
