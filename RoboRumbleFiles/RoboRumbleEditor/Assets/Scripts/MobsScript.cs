/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the behavior shared by all moving entities except for the movment per frame
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsScript : MonoBehaviour
{
    public float speed; //creates speed variable
    public int numLives;    //creates number of lives variable
    public float horizonatlLimit;   //creates horizontalLimit variable for clamping
    public float verticalLimit; //creates verticalLimit variable for clamping

    public Vector2 ScreenBounds;    //creates Screenbounds variable for use in clamping movement

    //sets the limits to those based on the screen size
    private void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        verticalLimit = ScreenBounds.y;
        horizonatlLimit = ScreenBounds.x;
    }
}
