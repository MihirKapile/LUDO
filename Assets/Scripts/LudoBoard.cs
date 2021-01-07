using System.Collections;
using UnityEngine;

public class LudoBoard : MonoBehaviour
{
    public int numberGot;
    public string[] tags = { "blue", "yellow", "green", "red" };
    public int NumberOfPlayers;
    // 0 B, 1 Y , 2 G ,3 R
    private void Start()
    {
        StartCoroutine(SequenceEnum());
    }

    public IEnumerator SequenceEnum()
    {
        /*DiceRolll
         * get the number face
         * Check pos of piece
         *   for each piece
         *      if(dice==6){ Selection all}
         *      if(not){select only not at home}
         *      if all pieace atHome = move to next player
         *  Now after selection
         *      if(piece athome, move to index one)
         *      if(piece was elswhere, move steps with number)
         *  After movement
         *      if(dice==6) {repeat above}
         *      else{move to next player}
        */
        yield return new WaitForSeconds(1f);
    }
}
