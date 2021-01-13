using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<PlayerMovement> PlayerList = new List<PlayerMovement>();
    public PathObjects pathParent;
    public bool Star;

    void Start()
    {
        pathParent = GetComponentInParent<PathObjects>();
    }

    //private void Update()
    //{
    //    if(PlayerList.Count == 1)
    //    {
    //        ScaleAndPosAll();
    //    }
    //}
    public void AddPlayer(PlayerMovement player_)
    {
        PlayerList.Add(player_);
        if (PlayerList.Count > 1)
        {
            player_.isAlone = false;
            toDestroyOtherPlayers(player_);
        }
        else
        {
            player_.isAlone = true;
        }
        ScaleAndPosAll();
    }

    public void RemovePlayer(PlayerMovement player_)
    {
        if (PlayerList.Contains(player_))
        {
            player_.isAlone = true;
            PlayerList.Remove(player_);
        }
        else
        {
            Debug.Log("Not found");
        }
        ScaleAndPosAll();

    }

    public void ScaleAndPosAll()
    {
        int count = PlayerList.Count;

        bool isOdd = (count % 2) == 0 ? false : true ;

        int extent = count/2;
        int counter = 0;

        int spriteLayers = 1 ;

        if (isOdd)
        {
            for (int i = -extent; i <= extent; i++)
            {
                PlayerList[counter].transform.localScale = new Vector3(pathParent.scales[PlayerList.Count - 1], pathParent.scales[PlayerList.Count - 1], 1f);
                PlayerList[counter].transform.position = new Vector3(this.transform.position.x + (i*pathParent.position[count-1]),this.transform.position.y,0f);
                counter++;
            }
        }
        else
        {
            for (int i = -extent; i < extent; i++)
            {
                PlayerList[counter].transform.localScale = new Vector3(pathParent.scales[PlayerList.Count - 1], pathParent.scales[PlayerList.Count - 1], 1f);
                PlayerList[counter].transform.position = new Vector3(transform.position.x + (i * pathParent.position[count - 1]), transform.position.y, 0f);
                counter++;
            }
        }

        for (int i = 0; i < PlayerList.Count; i++)
        {
            PlayerList[i].GetComponent<SpriteRenderer>().sortingOrder = spriteLayers;
            spriteLayers++;
        }
    }

    public void toDestroyOtherPlayers(PlayerMovement player_)
    {
        int count = PlayerList.Count;
        Debug.Log(count);
        player_.GetComponent<SpriteRenderer>().sortingOrder = PlayerList[PlayerList.Count-1].GetComponent<SpriteRenderer>().sortingOrder+1;
        for (int i = 0; i < count; i++)
        {

            if (!player_.gameObject.CompareTag(PlayerList[i].gameObject.tag))
            {
                PlayerList[i].toDestroy = true;
                //RemovePlayer(PlayerList[i]);
            }
            else
            {
                PlayerList[i].toDestroy = false;
            }

        }
    }
}

