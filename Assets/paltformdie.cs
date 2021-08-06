using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paltformdie : MonoBehaviour
{
    public playercontroller Playercontroller;
    public void OnTriggerEnter2D(Collider2D collision)

    {
        if(collision.CompareTag("Player"))
        {
            Playercontroller.KillPlayer();
        }
        
    }
}
