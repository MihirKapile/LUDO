using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PathObjects Path;
    //public bool canMove;
    public bool atHome;
    public bool canBeSelected;
    public DiceRoll dr;
    
    public LudoBoard lb;
    public void Awake()
    {
        atHome = true;
        Path = FindObjectOfType<PathObjects>();
        lb = FindObjectOfType<LudoBoard>();
        dr = FindObjectOfType<DiceRoll>();
    }

    public IEnumerator MovePiece(int[] pieceIndex,int currentPos,int moves)
    {
        for (int i = currentPos; i < currentPos + moves; i++)
        {
            int idx = pieceIndex[i];
            if (Path.outerPaths[idx] != null)
            {
                this.transform.position = Path.outerPaths[idx].transform.position;
            }
            yield return new WaitForSeconds(0.5f);

        }
    }

    public void SelectingPiece()
    {
        if (gameObject.CompareTag(lb.tags[dr.CheckPosition()]))
        {
            //canMove = true;
            //atHome = false;
            if (lb.numberGot == 5)
            {
                canBeSelected = true;
            }
            else if (!atHome)
            {
                canBeSelected = true;
            }
        }
    }

    bool max=false;

    public void Selection()
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

        else if (!canBeSelected)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }

    }

}
