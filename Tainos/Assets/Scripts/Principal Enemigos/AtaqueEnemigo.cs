using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{

    
    Animator animator;
    Enemigo enemigo;

    public int damage;
    public float coolDownAtaques;
    public float tiempoAtaqueInicial;

    private void Awake()
    {
        
        animator = transform.GetComponent<Animator>();
        enemigo = GetComponent<Enemigo>();


    }
    void Update()
    {
        if (Estados.EstadoJuego == Estados.eEstadoJuego.Play)
        {
            if (!animator.GetBool("isMoving") && coolDownAtaques <= 0)
            {

                enemigo.attack = true;
                coolDownAtaques = tiempoAtaqueInicial;
            }
            else
            {
                enemigo.attack = false;
                coolDownAtaques -= Time.deltaTime;
            }

        }

        
    }


}
