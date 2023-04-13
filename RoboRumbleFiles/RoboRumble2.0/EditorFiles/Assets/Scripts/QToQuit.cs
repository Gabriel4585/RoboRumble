/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that waits for the q button to be pressed to quit the application
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QToQuit : MonoBehaviour
{
    /*every frame, checks to see if the Q key has been pressed
     * if Q is pressed, quits the game*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();

        }

    }
}