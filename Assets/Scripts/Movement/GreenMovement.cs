using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMovement : PlayerMovement
{
    public int[] greenIndex;
    public int currentPos;
    DiceRoll greenDice;
    private void Start()
    {
        greenDice = GetComponentInParent<GreenHome>().dr;
        greenIndex = new int[] {26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 64, 65, 66, 67, 68, 69};
        currentPos = 1;
    }
    private void Update()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == greenDice)
        {
            if (isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, greenIndex))
            {
                if (LudoBoard.lb.numberGot == 6)
                {
                    GetComponentInParent<GreenHome>().selectAll();
                    LudoBoard.lb.diceRoll = false;
                    StartCoroutine(LudoBoard.lb.OneMoreChance_enum());
                }
                else
                {
                    //GetComponentInParent<GreenHome>().deselectAll();
                    GetComponentInParent<GreenHome>().selectOnlyOustide();
                    if (GetComponentInParent<GreenHome>().checkAllatHome())
                    {
                        StartCoroutine(LudoBoard.lb.nextChance_enum());

                    }
                }
            }
            else if (!isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, greenIndex))
            {
                canBeSelected = false;
            }

            if (LudoBoard.lb.numberGot == 0)
            {
                GetComponentInParent<GreenHome>().deselectAll();
            }
            //greenDice.canDiceRoll = isMoveDone;
        }
        else
        {
            GetComponentInParent<GreenHome>().deselectAll();
            currentPos = 1;

        }
        SelectionAnimation();


        if (toDestroy)
        {
            DestroyPiece(greenIndex, currentPos);
        }
    }

    private void OnMouseDown()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == greenDice)
        {
            if (LudoBoard.lb.dr && canBeSelected)
            {
                if (!isReady)
                {
                    if (LudoBoard.lb.numberGot == 6)
                    {
                        LeavingHome(greenIndex);
                        currentPos = 1;
                        LudoBoard.lb.numberGot = 0;
                        return;
                    }
                }

                if (isReady)
                {
                    GetComponentInParent<GreenHome>().deselectAll();
                    canMove = true;

                    //greenDice.canDiceRoll = isMoveDone;

                }
                int r = LudoBoard.lb.numberGot;
                MovePiece(greenIndex, currentPos, r);
                LudoBoard.lb.numberGot = 0;
                currentPos += r;
            }
        }

    }
}
