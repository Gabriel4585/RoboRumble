/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the Nuke object's behavior
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D gotHit)
    {
        /*calls ActivateNuke method when player runs into object then destroys itself
         * compiles refrence of all active objects with enemy tag and destroys them all*/
        if (gotHit.CompareTag("Player"))
        {
           Debug.Log("Player Ran into Nuke");
            PlayerScript playerObject = gotHit.GetComponent<PlayerScript>();
            playerObject.ActivateNuke();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
            for(int i=0; i<enemies.Length; ++i)
            {
                Destroy(enemies[i]);
            }
            Destroy(gameObject);
        }
        
    }
    
}
