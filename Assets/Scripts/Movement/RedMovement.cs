using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMovement : PlayerMovement
{
    public int[] redIndex;
    public int currentPos;
    DiceRoll redDice;
    private void Start()
    {
        redDice = GetComponentInParent<RedHome>().dr;
        redIndex = new int[] { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51,0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 58, 59, 60, 61, 62, 63 };
        currentPos = 1;
    }
    private void Update()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == redDice)
        {
            if (isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, redIndex))
            {
                if (LudoBoard.lb.numberGot == 6)
                {
                    GetComponentInParent<RedHome>().selectAll();
                }
                else
                {
                    //GetComponentInParent<RedHome>().deselectAll();
                    GetComponentInParent<RedHome>().selectOnlyOustide();
                }
            }
            else if (!isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, redIndex))
            {
                canBeSelected = false;
            }

            if (LudoBoard.lb.numberGot == 0)
            {
                GetComponentInParent<RedHome>().deselectAll();
            }
            //redDice.canDiceRoll = isMoveDone;
        }
        else
        {
            GetComponentInParent<RedHome>().deselectAll();
            currentPos = 1;
        }
        SelectionAnimation();


        if (toDestroy)
        {
            DestroyPiece(redIndex, currentPos);
        }
    }

    private void OnMouseDown()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == redDice)
        {
            if (LudoBoard.lb.dr && canBeSelected)
            {
                if (!isReady)
                {
                    if (LudoBoard.lb.numberGot == 6)
                    {
                        LeavingHome(redIndex);
                        LudoBoard.lb.numberGot = 0;
                        return;
                    }
                }

                if (isReady)
                {
                    GetComponentInParent<RedHome>().deselectAll();
                    canMove = true;

                    //redDice.canDiceRoll = isMoveDone;

                }
                int r = LudoBoard.lb.numberGot;
                MovePiece(redIndex, currentPos, r);
                LudoBoard.lb.numberGot = 0;
                currentPos += r;
            }
        }

    }

}
