/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the behavior of bullets travelling right
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBulletScript : BaseBulletScript
{
    public float projectileSpeed = 5f;  //projectile speed variable
    public Rigidbody2D projectilePhysics;   //rigidbody for the trigger events
    private Transform shooter;  //transform variable for starting position

    //moves projectile in a straight line right from initialization point
    void Start()
    {
        projectilePhysics.velocity = transform.right * projectileSpeed;
    }

    
}
