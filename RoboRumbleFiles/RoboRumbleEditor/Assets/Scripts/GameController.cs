/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that operates the game behavior
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //makes sure only one GameController object exists at a time
    private static GameController instance;
    public static GameController Instance { get { return instance; } }

    public PlayerScript playerObject;   //holds playerObject refrence
    public GameObject rightProjectilePreFab;    //holds refrence to right projectile prefab
    public GameObject leftProjectilePreFab;     //holds refrence to left projectile prefab
    public Transform rightFirePoint;    //holds refrence to right projectile fire point
    public Transform leftFirePoint;     //holds refrence to left projectile fire point
    public int playerScore = 0;     //playerscore variable
    public float spawnTime = 6f;    //default spawn time
    public int playerIsAlive;   //int acting as a boolean saying if the player is still alive

    public GameObject[] botPrefabs; //array of all bot prefabs
    public int typeOfBot;   //int of position in array for type of bot about to spawned in
    public Transform[] enemySpawnLocations; //array of all enemy spawn points
    public Transform enemySpawnPoint;   //position of spawn point about to be used to spawn in enemy

    public GameObject[] itemPrefabs;    //array of all item prefabs
    public int typeOfItem;  //int of position in array for type of item about to spawned in
    public Transform[] itemSpawnLocations;  //array of all item spawn points
    public int nextItemSpawn;   //int of position in array for spawn location about to be used
    public Transform itemSpawnPoint;    //position of spawn point about to be used to spawn in items

    public Text playerLifeUI;   //text variable showing how many lives the player has left
    public Text playerScoreUI;  //text object showing the player's score

    public CanvasGroup DeathScreenCanvas;   //canvas group for everything shown after player dies
    public Text finalScoreUI;   //text object used to display final score

    public CanvasGroup powerActivatedCanvas;    //canvas group containing poweractivation text
    public Text powerActivatedText;     //text object saying an item was activated

    //destroys any duplicates of gameObjects
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    //calls SetUp method
    void Start()
    {
        SetUp();
    }

    /*starts the spawn of enemies and items, turns off the death screen, chooses a random item type to spawn next
     * sets text and PlayerIsAlive to default settings */
    public void SetUp()
    {
        StartCoroutine(StartSpawningEnemies());
        StartCoroutine(StartSpawningItems());
        nextItemSpawn = Random.Range(0, 3);
        TurnOffDeathScreen();
        powerActivatedText.text = " was activated!";
        
        playerIsAlive = 1;
    }

    //checks every frame for player movement and if the left mouse button was pressed
    void Update()
    {
        playerObject.Move();
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
        
    }

    //instantiates right and left projectile prefabs in their respective firing positions
    public void Shoot()
    {
        Instantiate(rightProjectilePreFab, rightFirePoint.position, rightFirePoint.rotation);
        Instantiate(leftProjectilePreFab, leftFirePoint.position, leftFirePoint.rotation);
    }

    //displays the number of lives the player has
    public void DisplayLives(int numPlayerLives)
    {
        playerLifeUI.text = "Lives: " + numPlayerLives;
    }

    //displays the player's score
    public void DisplayScore()
    {
        playerScoreUI.text = "Score: " + playerScore; 
    }

    /* calls SpawnEnemies method and continues to call SpawnEnemies method after the delay
     * continously shortens the delay reaching a minimum of 2.5 seconds between spawning of enemies
     * stops when player dies*/
    IEnumerator StartSpawningEnemies()
    {
        SpawnEnemies();
        while (playerIsAlive == 1)
        {
            yield return new WaitForSeconds(spawnTime);
            if (playerIsAlive == 1)
            {
                SpawnEnemies();
            }
            spawnTime=spawnTime-1;
            if (spawnTime<2.5f)
            {
                spawnTime = 2.5f;
            }
        }
        
    }

    //calls SpawnItems method a random item every 35 seconds while the player is still alive
    IEnumerator StartSpawningItems()
    {
        while (playerIsAlive == 1)
        {
            yield return new WaitForSeconds(35);
            if(playerIsAlive == 1)
            {
                SpawnItems();
            }
        }
            
    }

    //spawns a random type of enemy at a random location 
    public void SpawnEnemies()
    {
        enemySpawnPoint = enemySpawnLocations[Random.Range(0,4)];
        typeOfBot = Random.Range(0,3);
        Instantiate(botPrefabs[typeOfBot], enemySpawnPoint.position, enemySpawnPoint.rotation);
    }

    //spawns a random type of item at the next spawn point in the array
    public void SpawnItems()
    {
        GameObject[] allItems = GameObject.FindGameObjectsWithTag("Supplies");
        if (allItems.Length < 3)
        {
            itemSpawnPoint = itemSpawnLocations[nextItemSpawn];
            typeOfItem = Random.Range(0,3);
            Instantiate(itemPrefabs[typeOfItem], itemSpawnPoint.position, itemSpawnPoint.rotation);
            nextItemSpawn++;
            if (nextItemSpawn >= 3)
            {
                nextItemSpawn = 0;
            }
        }
        
    }

    /* activates when player is dead
     * turns on death screen, sets playerIsAlive to false and destroys all active enemies*/
    public void PlayerDied()
    {
        playerIsAlive = 0;
        TurnOnDeathScreen();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < enemies.Length; ++i)
        {
            Destroy(enemies[i]);
        }
    }

    //turns off death screen canvas
    private void TurnOffDeathScreen()
    {
        DeathScreenCanvas.alpha = 0;
        DeathScreenCanvas.blocksRaycasts = false;
        DeathScreenCanvas.interactable = false;
    }

    //turns on death screen canvas
    private void TurnOnDeathScreen()
    {
        DeathScreenCanvas.alpha = 1;
        DeathScreenCanvas.blocksRaycasts = true;
        DeathScreenCanvas.interactable = true;
        finalScoreUI.text = "Score: " + playerScore;
        
    }

    //shows active power text
    public void ShowPowerActiveText(string itemActivated)
    {
        powerActivatedCanvas.alpha = 1;
        powerActivatedCanvas.blocksRaycasts = true;
        powerActivatedCanvas.interactable = true;
        powerActivatedText.text = itemActivated + "  was activated!";
    }
}
