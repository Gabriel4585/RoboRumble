/*Gabriel Garcia
 * 002344584
 * gagarcia@chapman.edu
 * CPSC 236-02 Visual Programing
 * RoboRumble
 * 
 * Script that controls the menu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public CanvasGroup RulesCanvas; //variable for canvas containing instructions
    public CanvasGroup MenuCanvas;  //variable for main menu canvas

    //calls HideCanvas and ShowCanvas method
    public void Start()
    {
        HideCanvas(RulesCanvas);
        ShowCanvas(MenuCanvas);
    }

    //Loads game scene when button pressed
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    //Quits the app when quit button is pressed
    public void QuitApp()
    {
        Application.Quit();
    }

    //Hides Menu canvas and shows Instructions canvas when button is pressed
    public void InstructionButton()
    {
        HideCanvas(MenuCanvas);
        ShowCanvas(RulesCanvas);
    }

    //Hides Rules canvas and shows menu canvas when button is pressed
    public void ReturnToMenu()
    {
        HideCanvas(RulesCanvas);
        ShowCanvas(MenuCanvas);
    }

    //shows canvas that is taken in as a parameter
    public void ShowCanvas(CanvasGroup canvasToTurnOn)
    {
        canvasToTurnOn.alpha = 1;
        canvasToTurnOn.blocksRaycasts = true;
        canvasToTurnOn.interactable = true;
    }

    //hides canvas that is taken in as a parameter
    public void HideCanvas(CanvasGroup canvasToTurnOff)
    {
        canvasToTurnOff.alpha = 0;
        canvasToTurnOff.blocksRaycasts = false;
        canvasToTurnOff.interactable = false;
    }

    
}
