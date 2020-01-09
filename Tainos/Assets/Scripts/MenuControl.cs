using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;
public class MenuControl : MonoBehaviour
{

    public GameObject playMenu;
    public GameObject principalMenu;
    public GameObject botonContinuar;

    

    
    public void PlayGame()
    {
        principalMenu.SetActive(false);
        playMenu.SetActive(true);

        if(File.Exists(Application.persistentDataPath + "/CaonaboGame.xml"))
        {
            botonContinuar.SetActive(true);
        }
        else
        {
            botonContinuar.SetActive(false);
        }

    }
    public void Regresar()
    {
        principalMenu.SetActive(true);
        playMenu.SetActive(false);
    }
    public void nuevaPartida()
    {
        SceneManager.LoadScene("EscenaControles");
        Estados.NewGame = true;
    }
    public void continuarPartida()
    {
        
        SceneManager.LoadScene("Mapa Principal");
        Estados.NewGame = false;



    }

    public void LoadCredits()
    {

        SceneManager.LoadScene("Credits");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
