using System.Collections;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public LudoBoard lb;
    [SerializeField] Sprite[] numberFaces;
    [SerializeField] Sprite initialDice;
    [SerializeField] GameObject Anim;
    [SerializeField] SpriteRenderer numberGotFace;
    [SerializeField] PathObjects Path;
    public int pos;

    public bool canDiceRoll=true;

    Coroutine transition_Co;
    private void Awake()
    {
        lb = FindObjectOfType<LudoBoard>();
        InitalDice();        
    }
    void InitalDice()
    {
        numberGotFace.sprite = initialDice;
        numberGotFace.gameObject.SetActive(true);
        Anim.SetActive(false);
    }

    private void Update()
    {
        canDiceRoll = LudoBoard.lb.diceRoll;
        if (this != LudoBoard.lb.dr)
        {
            numberGotFace.sprite = initialDice;
            
        }
    }
    
    private void OnMouseDown()
    {
        transition_Co = StartCoroutine(TransitionEnum());
        
    }

    IEnumerator TransitionEnum()
    {
        if (canDiceRoll)
        {
            canDiceRoll = false;
            yield return new WaitForEndOfFrame();
            numberGotFace.gameObject.SetActive(false);
            Anim.SetActive(true);

            yield return new WaitForSeconds(0.6f);

            LudoBoard.lb.numberGot = Random.Range(0, 6); //(0,6)
            LudoBoard.lb.dr = this;

            numberGotFace.sprite = numberFaces[LudoBoard.lb.numberGot];
            LudoBoard.lb.numberGot++;
            numberGotFace.gameObject.SetActive(true);
            Anim.SetActive(false);
            yield return new WaitForEndOfFrame();
            canDiceRoll = true;
            if (transition_Co != null)
            {
                StopCoroutine(transition_Co);
            }
        }

    }
}
