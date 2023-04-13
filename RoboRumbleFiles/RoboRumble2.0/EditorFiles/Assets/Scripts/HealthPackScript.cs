/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the health pack object's behavior
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : MonoBehaviour
{
    //calls RestoreLife method when player runs into object then destroys itself
    private void OnTriggerEnter2D(Collider2D gotHit)
    {
        if (gotHit.CompareTag("Player"))
        {
            Debug.Log("Player Ran into Health Pack");
            PlayerScript playerObject = gotHit.GetComponent<PlayerScript>();
            if (playerObject != null)
            {
                playerObject.RestoreLife();
                Destroy(gameObject);
            }
        }
        
    }
}
