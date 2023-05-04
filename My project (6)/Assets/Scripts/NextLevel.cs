using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public bool pl1;
    public bool pl2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        //

        if (collision.gameObject.tag == "Player1" )
        {
            pl1 = true;
            

        }
        if (collision.gameObject.tag == "Player2")
        {
            pl2 = true;

        }
        if(pl1 != false && pl2 != false)
        {
            LevelController.instance.isEndGame();
        }





    }
}
