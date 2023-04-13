/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the behavior of bullets travelling left
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBulletSript : BaseBulletScript
{
    public float projectileSpeed = 5f;  //projectile speed variable
    public Rigidbody2D projectilePhysics;   //projectile rigidbody used for trigger effects
    private Transform shooter;  //transform position for shooter variable

    //moves projectile in a straight line left from initialization point
    void Start()
    {
        projectilePhysics.velocity = (transform.right*-1) * projectileSpeed;
    }

    
}
