/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the player behavior
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MobsScript
{
    public Boolean hasForceField = false;   //boolean saying if the force field is active
    public GameController gameDriver;   //GameController type variable that holds the refrence for the game controller
    public float forceFieldDuration = 10;
    public GameObject originalSprite;   //default sprite of player
    public GameObject fieldActiveSprite;    //altered blue sprite of player to indicate when force field is active
    private SpriteRenderer spriteRender;    //holds refrence for sprite renderer

    public CanvasGroup powerActivatedCanvas;    //holds refrence to canvas that displays text saying an item was activated
    public Text powerActivatedText; //text object that has the refrence to the power up text

    public float playerHalfWidth;   //half of the width of the player, used to clamp it properlly
    public float playerHalfHieght;  //half of the height of the player, used to clamp it properlly

    /* calls SetUpPlayer method, and sets boundries based on screen size
     * initializes sprite render object and sets playerHalfWidth and playerHalfHeight */
    void Start()
    {
        SetUpPlayer();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        verticalLimit = ScreenBounds.y;
        horizonatlLimit = ScreenBounds.x;

        spriteRender = originalSprite.GetComponent<SpriteRenderer>();
        playerHalfWidth = spriteRender.bounds.extents.x;
        playerHalfHieght = spriteRender.bounds.extents.y;
    }

    //initializes all the variables for the player to a defualt state and calls the TurnOffPowerActivationText method
    private void SetUpPlayer()
    {
        speed = 4.5f;
        numLives = 3;
        originalSprite.SetActive(true);
        fieldActiveSprite.SetActive(false);
        TurnOffPowerActivationText();
    }

    /*subtracts a life from the player and calls KillPlayer method if the player has 0 lives left
     * Calls UpdateLiveCount after every hit*/
    public void LoseLife()
    {
        if (hasForceField)
        {
            Debug.Log("damage blocked by force field");
        }
        else
        {
            Debug.Log("player lives before: " + numLives);
            numLives = numLives - 1;
            Debug.Log("player lives after: " + numLives);
            if (numLives <= 0)
            {
                Debug.Log("player died");
                KillPlayer();
            }
            UpdateLiveCount();
        }
    }

    /* Every frame, moves the player based on keyboard input
     * also clamps the movment of the player to never go farther than the set limits based on the screen size*/
    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position = transform.position + (movement * Time.deltaTime * speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -horizonatlLimit+playerHalfWidth, horizonatlLimit-playerHalfWidth), Mathf.Clamp(transform.position.y, -verticalLimit+playerHalfHieght, verticalLimit-playerHalfHieght),0f);  //FIXME vertical clamp not working
    }

    //sets the player's lives to 3 (the max) whenever the player runs into the healthpack item and calls the UpdateLivesCount and TurnOffPowerActivationText methods
    public void RestoreLife()
    {
        numLives = 3;
        UpdateLiveCount();
        gameDriver.ShowPowerActiveText("Health Pack");
        Invoke("TurnOffPowerActivationText", 2f);
    }

    //calls the  TurnOnForceField then turns it off after the duration. Also turns off and on the power activation text
    public void ActivateForceField()
    {
        TurnOnForceField();
        Invoke("TurnOffForceField",forceFieldDuration);
        gameDriver.ShowPowerActiveText("Force Field");
        Invoke("TurnOffPowerActivationText",2f);
    }

    //shows text saying the nuke object has been activated
    public void ActivateNuke()
    {
        gameDriver.ShowPowerActiveText("Nuke");
        Invoke("TurnOffPowerActivationText", 2f);
    }

    //changes the hasForceField variable to false and sets the original sprite as active and the altered sprite as false
    private void TurnOffForceField()
    {
        originalSprite.SetActive(true);
        fieldActiveSprite.SetActive(false);
        hasForceField = false;
    }

    //changes the hasForceField variable to false and sets the original sprite as false and the altered sprite as active
    private void TurnOnForceField()
    {
        originalSprite.SetActive(false);
        fieldActiveSprite.SetActive(true);
        hasForceField = true;
    }

    //calls the DisplayLives method on the gameDriver
    public void UpdateLiveCount()
    {
        gameDriver.DisplayLives(numLives);
    }

    //calls the PlayerDied method on the gameDriver
    public void KillPlayer()
    {
        gameDriver.PlayerDied();
    }

    //turns off the poweractivation text canvas
    public void TurnOffPowerActivationText()
    {
        powerActivatedCanvas.alpha = 0;
        powerActivatedCanvas.blocksRaycasts = false;
        powerActivatedCanvas.interactable = false;
    }
}
