using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    public GameObject gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //scores goal based on which player hit the trigger first
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().Score(collision.gameObject.name);
        }
    }
    
}
