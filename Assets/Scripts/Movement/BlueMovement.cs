using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovement : PlayerMovement
{

    public int[] blueIndex;
    public int currentPos;
    public DiceRoll blueDice;
    private void Start()
    {
        blueDice = GetComponentInParent<BlueHome>().dr;
        //playerSpecificHome = GetComponentInParent<BlueHome>().Home[];
        blueIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 52, 53, 54, 55, 56, 57 };
        currentPos = 0;
    }

    private void Update()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == blueDice)
        {
            if (isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, blueIndex))
            {
                if (LudoBoard.lb.numberGot == 6)
                {
                    GetComponentInParent<BlueHome>().selectAll();
                    LudoBoard.lb.diceRoll = false;
                    StartCoroutine(LudoBoard.lb.OneMoreChance_enum());
                }
                else
                {
                    GetComponentInParent<BlueHome>().selectOnlyOustide();
                    if (GetComponentInParent<BlueHome>().checkAllatHome())
                    {
                        StartCoroutine(LudoBoard.lb.nextChance_enum());

                    }
                }
            }
            else if (!isPathPointAVailableToMove(LudoBoard.lb.numberGot, currentPos, blueIndex))
            {
                canBeSelected = false;
            }

            if (LudoBoard.lb.numberGot == 0)
            {
                GetComponentInParent<BlueHome>().deselectAll();
            }
            //blueDice.canDiceRoll = isMoveDone;
        }
        else
        {
            GetComponentInParent<BlueHome>().deselectAll();

        }
        SelectionAnimation();


        if (toDestroy)
        {
            DestroyPiece(blueIndex,currentPos);
            currentPos = 0;
        }
    }

    private void OnMouseDown()
    {
        if (LudoBoard.lb.dr != null && LudoBoard.lb.dr == blueDice)
        {
            if (LudoBoard.lb.dr && canBeSelected)
            {
                if (!isReady)
                {
                    if (LudoBoard.lb.numberGot == 6)
                    {
                        LeavingHome(blueIndex);
                        currentPos = 1;
                        LudoBoard.lb.numberGot = 0;
                        return;
                    }
                }

                if (isReady)
                {
                    GetComponentInParent<BlueHome>().deselectAll();
                    canMove = true;

                    //blueDice.canDiceRoll = isMoveDone;

                }
                int r = LudoBoard.lb.numberGot;
                MovePiece(blueIndex, currentPos, r);
                currentPos += r;
                LudoBoard.lb.numberGot = 0;
            }
        }

    }


}
