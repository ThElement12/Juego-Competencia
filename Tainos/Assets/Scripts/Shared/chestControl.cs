using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestControl : MonoBehaviour
{
    public AudioSource mySound;
    Animator myAnimator;
    public GameObject ObjetoContenido;
    public GameObject Carta;
    Inventario inventario;
    

    public bool abierto = false; //Se evita que se tome un mismo objeto mas de una vez

    [TextArea(3,3)]
    public string[] TextoCarta;
    public int cantidadObjetos;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        inventario = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventario>();
    }   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !myAnimator.GetBool("isOpen"))
        {
            TextoAvisoAlJugador.SetTexto("INTERACTUAR");
            if (Input.GetKey(KeyCode.E) || Input.GetButtonDown("Interactuar"))
            {
                TextoAvisoAlJugador.SetTexto("");
                mySound.Play();
                myAnimator.SetBool("isOpen", true);
                if (!abierto)
                {
                    if (ObjetoContenido.transform.tag == "Flecha")
                    {
                        Inventario.totalFlechas+= cantidadObjetos;
                        abierto = true;
                    }
                    else if (ObjetoContenido.transform.tag == "Pocion")
                    {
                        inventario.Pocion = Instantiate(ObjetoContenido.gameObject);
                        inventario.Pocion.SetActive(false);
                        Inventario.totalPociones+= cantidadObjetos;
                        abierto = true;
                    }
                    else if (ObjetoContenido.tag == "Carta")
                    {
                        Carta.GetComponent<DialogoCarta>().AbrirCarta(TextoCarta);
                        abierto = true;

                    }
                }
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TextoAvisoAlJugador.SetTexto("");
        }
    }



}
