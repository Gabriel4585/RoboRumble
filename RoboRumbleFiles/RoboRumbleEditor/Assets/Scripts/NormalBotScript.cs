/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the behavior of normal bots
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBotScript : EnemiesScript
{
    private float botSpeed = 2.5f;
    private Rigidbody2D rb2D;

    /* Start method sets number of lives, rigidbody variable, and the x y limits
     * Also sets the screen bounds in order to limit movment of the bot*/
    void Start()
    {
        numLives = 3;
        rb2D = GetComponent<Rigidbody2D>();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        verticalLimit = ScreenBounds.y;
        horizonatlLimit = ScreenBounds.x;
    }

    /* Every frame, moves the bot closer to the player
    * also clamps the movment of the bot to never go farther than the set limits based on the screen size*/
    void Update()
    {   
        playerPosition = Player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position,playerPosition,botSpeed*Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -horizonatlLimit, horizonatlLimit), Mathf.Clamp(transform.position.y, -verticalLimit, verticalLimit), 0f);
    }

}
