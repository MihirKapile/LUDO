using UnityEngine;

public class PlayerHome : MonoBehaviour
{
    public Transform[] Home;
    public GameObject piece;

    public void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            Vector2 tempPos = Home[i].position;
            GameObject dot_c = Instantiate(piece, tempPos, Quaternion.identity);
            dot_c.transform.parent = this.transform;
            dot_c.name = i.ToString();
        }
    }

}
