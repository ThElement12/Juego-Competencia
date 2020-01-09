using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    public GameObject PauseMenu;
    // Update is called once per frame
    private void Start()
    {
       
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Estados.EstadoJuego == Estados.eEstadoJuego.Pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }


        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Estados.EstadoJuego = Estados.eEstadoJuego.Play;
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Estados.EstadoJuego = Estados.eEstadoJuego.Pause;
    }
    
    public void LoadMenu()
    {

    }
    public void GuardarYSalir()
    {
        SaveState.SaveGame(Estados.guardarItems(),Estados.guardarCofres(),Estados.guardarJefes());
        SceneManager.LoadScene("Menu");

    }
    public void Salir()
    {
        SceneManager.LoadScene("Menu");
    }
}
