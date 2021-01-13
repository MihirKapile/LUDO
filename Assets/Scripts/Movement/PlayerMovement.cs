using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Execution;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PathObjects Path;
    public bool canMove;
    public bool isReady;
    public bool canBeSelected;
    public bool isAlone;
    public bool toDestroy;
    public Path prev_point;
    public Path curr_point;
    public Transform playerSpecificHome;
    [HideInInspector]
    public LudoBoard lb;

    Coroutine move_co;
    Coroutine destroy_co;
    public void Awake()
    {
        isAlone = true;
        Path = FindObjectOfType<PathObjects>();
        lb = FindObjectOfType<LudoBoard>();
        //playerSpecificHome = this.transform;
        //isMoveDone = true;
        //dr = FindObjectOfType<DiceRoll>();
    }

    
    public void LeavingHome(int[] pieceIndex)
    {
        isReady = true;
        this.transform.position = Path.outerPaths[pieceIndex[0]].transform.position;
        //isMoveDone = true;
        prev_point = Path.outerPaths[pieceIndex[0]].GetComponent<Path>();
        curr_point = Path.outerPaths[pieceIndex[0]].GetComponent<Path>();
        curr_point.AddPlayer(this);
    }
    
    public void MovePiece(int[] pieceIndex, int currentPos, int moves)
    {
        move_co = StartCoroutine(MovePiece_enum(pieceIndex, currentPos, moves));
    }

    public IEnumerator MovePiece_enum(int[] pieceIndex, int currentPos, int moves)
    {
        if (canMove)
        {
            for (int i = currentPos; i < currentPos + moves; i++)
            {
                if (isPathPointAVailableToMove(moves, currentPos, pieceIndex))
                {
                    int idx = pieceIndex[i];
                    if (Path.outerPaths[idx] != null)
                    {
                        this.transform.position = Path.outerPaths[idx].transform.position;
                        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
                        LudoBoard.lb.diceRoll = false;
                    }
                    yield return new WaitForSeconds(0.5f);
                }
                if (i == currentPos + moves - 1)
                {
                    LudoBoard.lb.diceRoll = true;
                    this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

                    curr_point = Path.outerPaths[pieceIndex[i]].GetComponent<Path>();

                }
            }
        }
        if (isPathPointAVailableToMove(moves, currentPos, pieceIndex))
        {
            prev_point.RemovePlayer(this);
            curr_point.AddPlayer(this);
            curr_point.ScaleAndPosAll();
            prev_point = curr_point;
        }
        if (move_co != null)
        {
            StopCoroutine(move_co);
        }
    }

    public bool isPathPointAVailableToMove(int numofStepsToMove_, int currentPos_, int[] pieceIndex_)
    {
        int leftPoints = pieceIndex_.Length - currentPos_;
        if (leftPoints >= numofStepsToMove_)
        {
            return true;
        }
        return false;
    }



    public void DestroyPiece(int[] pieceIndex, int currentPos)
    {
        destroy_co = StartCoroutine(DestroyPiece_enum(pieceIndex, currentPos));
    }

    public IEnumerator DestroyPiece_enum(int[] pieceIndex, int currentPos)
    {

        toDestroy = false;
        this.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        for (int i = currentPos - 1; i >= -1; i--)
        {
            if (i > -1)
            {
                if (Path.outerPaths[pieceIndex[i]] != null)
                {
                    this.transform.position = Path.outerPaths[pieceIndex[i]].transform.position;
                    LudoBoard.lb.diceRoll = false;
                }
            }
            else if (i == -1)
            {
                this.transform.position = playerSpecificHome.position;
                LudoBoard.lb.diceRoll = true;

            }
            yield return new WaitForSeconds(0.2f);       
        }

        curr_point.RemovePlayer(this);
        Reset();


        if (destroy_co != null)
        {
            StopCoroutine(destroy_co);
        }
    }


    private void Reset()
    {
        canMove=false;
        isReady=false;
        canBeSelected=false;
        isAlone=true;
        toDestroy=false;
        curr_point = null;
        prev_point = null;
    }
    bool max = false;

    public void SelectionAnimation()
    {
        if (canBeSelected)
        {
            float change = Time.deltaTime * 0.03f;
            Vector3 scaleChange = new Vector3(change, change, 0);
            if ((transform.localScale.y <= 0.11 && transform.localScale.y >= 0.09))
            {

                if (!max)
                {
                    transform.localScale += scaleChange;
                }
                else if (max)
                {
                    transform.localScale -= scaleChange;

                }

            }
            if (transform.localScale.y > 0.11f)
            {
                max = true;
                transform.localScale -= scaleChange;
            }
            if (transform.localScale.y < 0.09)
            {
                max = false;
                transform.localScale += scaleChange;
            }

        }

        else if (!canBeSelected && isAlone)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }

    }

}
