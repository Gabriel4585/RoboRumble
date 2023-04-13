/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * A script that controls the trigger events for the bullets shot by the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletScript : MonoBehaviour
{
    //subtracts a life from the mob that is hit with the bullet, then destroyes itself 
    private void OnTriggerEnter2D(Collider2D gotHit)
    {
        if (gotHit.CompareTag("Enemies"))
        {
            Debug.Log("Enemy hit");
            EnemiesScript enemy = gotHit.GetComponent<EnemiesScript>();
            if (enemy != null)
            {
                enemy.LosePart();
            }
            Destroy(gameObject);
        }
        if (gotHit.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            PlayerScript player = gotHit.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.LoseLife();
            }
            Destroy(gameObject);
        }

    }
}
