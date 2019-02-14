using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDestroyer : MonoBehaviour
{

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "ball")
        {
            Destroy(col.gameObject);
          GameManager.health -= 1;
        }
    }
}
