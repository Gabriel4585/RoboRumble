using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesScript : MobsScript
{
    public GameController gameController;
    public PlayerScript Player;
    public Vector2 playerPosition;
    public void Die()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        GameObject playerObject;
        GameObject driverObject;
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
            Player = playerObject.GetComponent<PlayerScript>();
        }

        if (GameObject.FindGameObjectsWithTag("GameController").Length > 0)
        {
            driverObject = GameObject.FindGameObjectsWithTag("GameController")[0];
            gameController = driverObject.GetComponent<GameController>();
        }
    }


    public void LosePart()
    {
        numLives = numLives - 1;
        if (numLives <= 0)
        {
            Die();
            Debug.Log("Bot Destroyed");
            gameController.playerScore += 10;
            gameController.DisplayScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D gotHit)
    {
        if (gotHit.CompareTag("Player"))
        {
            Debug.Log("Enemy ran into player");
            PlayerScript playerObject = gotHit.GetComponent<PlayerScript>();
            if (playerObject != null)
            {
                playerObject.LoseLife();
            }
        }
    }

    
}
