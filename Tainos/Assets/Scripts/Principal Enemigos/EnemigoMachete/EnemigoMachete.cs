using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMachete : MonoBehaviour
{
    GameObject jugador;
    float distanciaJugador;
    public float RangoAlerta;
    Animator animator;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanciaJugador = Vector3.Distance(jugador.transform.position, transform.position);

        animator.SetFloat("distanciaJugador", distanciaJugador);

        //Haciendo que el enemigo se voltee a ver al jugador
        if (transform.position.x - jugador.transform.position.x < 0)
        {
            
            transform.rotation = new Quaternion(0, 180, 0, 0);
        
        }
        else
        {
           
           transform.rotation = new Quaternion(0, 0, 0, 0);
         
        }


    }
}
