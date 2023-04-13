/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * A script that destroys the object that its attached to after a specified delay
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float Delay = 2.3f;  //variable specifing delay

    //destoys object after the delay
    void Start()
    {
        Destroy(gameObject, Delay);
    }
}
