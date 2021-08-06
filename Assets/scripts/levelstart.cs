using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelstart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playercontroller>() != null)
        {
            Debug.Log("level start");
        }
    }
}
