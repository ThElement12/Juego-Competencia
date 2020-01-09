using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{

    public GameObject VentanaDialogo;

    ///public bool dialogoAutomatico;
    [TextArea(3, 10)]
    public string[] TextoDialogo;
    bool hablando = false;
    public bool dialogoAutomatico;
    public bool dialogoFinal = false;
    bool dialogoRealizado = false;
    
    private void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (dialogoAutomatico && !dialogoRealizado)
            {
                if (!hablando)
                {
                    VentanaDialogo.GetComponent<DialogoCarta>().AbrirCarta(TextoDialogo);
                    VentanaDialogo.GetComponent<DialogoCarta>().final = dialogoFinal;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("mover", false);
                    hablando = true;
                    dialogoAutomatico = false;
                    if(transform.name == "zonaDialogoLiberacion1" || transform.name == "zonaDialogoLiberacion2" 
                    ||transform.name == "zonaDialogoLiberacion3")
                    {
                        Estados.indiosCapturados--;

                    }
                }
            }
            else if (!dialogoAutomatico)
            {
                TextoAvisoAlJugador.SetTexto("INTERACTUAR");
                if (Input.GetKey(KeyCode.E) || Input.GetButtonDown("Interactuar"))
                {
                    if (!hablando)
                    {

                        TextoAvisoAlJugador.SetTexto("");
                        VentanaDialogo.GetComponent<DialogoCarta>().AbrirCarta(TextoDialogo);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("mover", false);

                        hablando = true;
                    }
                }

            }
        }
        /*if(dialogoAutomatico == false)
        {
            if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) //Si el jugador se acerca a una zona y presiona E
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Estados>().EstadoJuego = Estados.eEstadoJuego.Pause;
                ventanaDialogo.SetActive(true);
            }
        }else
        {
            if (other.tag == "Player" && !dialogoVisto) 
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Estados>().EstadoJuego = Estados.eEstadoJuego.Pause;
                ventanaDialogo.SetActive(true);
                dialogoVisto = true;
            }
        }*/

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TextoAvisoAlJugador.SetTexto("");
            hablando = false;
        }
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<Estados>().EstadoJuego = Estados.eEstadoJuego.Play;

        //Destroy(ventanaDialogo);        
    }
    
}