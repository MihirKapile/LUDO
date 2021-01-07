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

    bool canDiceRoll=true;

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
    public int CheckPosition()
    {
        int i;
        for(i = 0; i < 4; i++)
        {
            if(Path.dicePath[i].transform.position == transform.position)
            {
                break;
            }
        }
        return i;
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
            lb.numberGot = Random.Range(0, 6);
            numberGotFace.sprite = numberFaces[lb.numberGot];
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
