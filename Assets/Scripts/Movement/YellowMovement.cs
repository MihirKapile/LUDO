using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMovement : PlayerMovement
{
    public int[] yellowIndex;
    public int currentPos;
    DiceRoll yellowDice;
    private void Start()
    {
        yellowDice = GetComponentInParent<YellowHome>().dr;
        yellowIndex = new int[] { 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 70, 71, 72, 73, 74, 75};
        currentPos = 1;
    }
    private void Update()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == yellowDice)
        {
            if (isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, yellowIndex))
            {
                if (LudoBoard.lb.numberGot == 6)
                {
                    GetComponentInParent<YellowHome>().selectAll();
                }
                else
                {
                    //GetComponentInParent<yellowHome>().deselectAll();
                    GetComponentInParent<YellowHome>().selectOnlyOustide();
                }
            }
            else if (!isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, yellowIndex))
            {
                canBeSelected = false;
            }

            if (LudoBoard.lb.numberGot == 0)
            {
                GetComponentInParent<YellowHome>().deselectAll();
            }
            //yellowDice.canDiceRoll = isMoveDone;
        }
        else
        {
            GetComponentInParent<YellowHome>().deselectAll();

        }
        SelectionAnimation();


        if (toDestroy)
        {
            DestroyPiece(yellowIndex, currentPos);
            currentPos = 1;

        }
    }

    private void OnMouseDown()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == yellowDice)
        {
            if (LudoBoard.lb.dr && canBeSelected)
            {
                if (!isReady)
                {
                    if (LudoBoard.lb.numberGot == 6)
                    {
                        LeavingHome(yellowIndex);
                        LudoBoard.lb.numberGot = 0;
                        return;
                    }
                }

                if (isReady)
                {
                    GetComponentInParent<YellowHome>().deselectAll();
                    canMove = true;

                    //yellowDice.canDiceRoll = isMoveDone;

                }
                int r = LudoBoard.lb.numberGot;
                MovePiece(yellowIndex, currentPos, r);
                LudoBoard.lb.numberGot = 0;
                currentPos += r;
            }
        }

    }
}
