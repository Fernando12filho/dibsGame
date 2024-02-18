using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            GameManager.gameManager.playerScore1 += 1;
            StartCoroutine(GameManager.gameManager.Goal());
        }
        if (collision.CompareTag("Player2"))
        {   
            GameManager.gameManager.playerScore2 += 1;
            StartCoroutine(GameManager.gameManager.Goal());
        }
    }
}
