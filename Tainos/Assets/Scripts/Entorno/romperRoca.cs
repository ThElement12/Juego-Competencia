using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class romperRoca : MonoBehaviour
{
    Animator animator;
    Inventario inventario;
    GameObject jugador;
    bool golpeRoca = false;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        animator = transform.GetComponent<Animator>();
    }
    private void Update()
    {
       
    }

    //Funcion para cambiar la animacion de la roca como "fases" de destruccion de la misma
    public void recibirAtaque()
    {

        if (Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Lanza) //La roca se ira rompiendo se se golpea con la lanza
        {
           
            if (animator.GetBool("fase1"))
            {
                animator.SetBool("fase1", false);
                animator.SetBool("fase2", true);
                
              
            }

            else if (animator.GetBool("fase2"))
            {
                animator.SetBool("fase2", false);
                animator.SetBool("fase3", true);
                return;
            }

            else if (animator.GetBool("fase3"))
            {
                Destroy(gameObject);
            }
        }
    }

   



}
