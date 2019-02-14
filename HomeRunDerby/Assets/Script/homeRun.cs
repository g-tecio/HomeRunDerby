using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeRun : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "ball")
        {
            Destroy(col.gameObject);
             GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore();
        }
    }

   
}
