using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controlara la animacion de ataque del personaje
public class ControlAnimAtaque: MonoBehaviour
{

    public AudioSource attackSound;
    Animator animator;
    Inventario inventario;

    public int indiceInventario = 1;
    
  


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();


    }

    
    void Update()
    {
        if (Estados.EstadoJuego == Estados.eEstadoJuego.Play && Estados.EstadoAccion == Estados.eEstadoAccionJugador.Nada)
        {
            animator.SetInteger("indiceObjeto", indiceInventario);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J) || Input.GetButtonDown("Fire1") )
            {
                attackSound.Play();
                Estados.EstadoJugador = Estados.eEstadoJugador.Atacando; //Cambiando al estado de ataque
                animator.SetBool("atacando", true);
                
            }
            else if (!Input.GetMouseButtonDown(0) || !Input.GetKeyDown(KeyCode.J) || !Input.GetButtonDown("Fire1"))
            {
                Estados.EstadoJugador = Estados.eEstadoJugador.Nada; //Cambiando al estado de ataque
                animator.SetBool("atacando", false);
            }

            //Atacando con el arco
            if (Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Arco)
            {
                if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J) || Input.GetButtonDown("Fire1")) && Inventario.totalFlechas > 0 && (!animator.GetBool("isOnStair")
                    && !animator.GetBool("isOnStairMoving") && !animator.GetBool("saltar")))
                {
                    Estados.EstadoArco = Estados.eEstadoArco.Disparando;
                    transform.GetComponent<Disparar>().DispararFlecha();
                    Estados.EstadoArco = Estados.eEstadoArco.Nada;
                }
            }
        }
    }
}
