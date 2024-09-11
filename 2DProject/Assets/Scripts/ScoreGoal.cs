using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    public GameObject gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Phase 1");
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().Score(collision.gameObject.name);
            //Debug.Log("Phase 2");
            //Debug.Log(collision.gameObject.name);
        }
    }
    
}
