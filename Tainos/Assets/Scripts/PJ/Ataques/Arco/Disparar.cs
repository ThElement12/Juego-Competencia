using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public float TIEMPOENTREFLECHAS; ///Limite que tiene que llegar la variable coolDown para volver a ser 0
    float cooldown; //Tiempo entre disparos


    public GameObject flechaPrefab;
    GameObject flecha;

    public Vector3 VelocidadInicialFlecha;
    public float angle;///Angulo del disparo
    public int damageFlecha;
    Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        cooldown += Time.deltaTime;
       
    }

    public void DispararFlecha()
    {
        if (cooldown > TIEMPOENTREFLECHAS && (!animator.GetBool("saltar") && !animator.GetBool("mover")) && Inventario.totalFlechas > 0)
        {
            
            //generando la flecha
            flecha = Instantiate(flechaPrefab);
            flecha.transform.position = new Vector3(transform.position.x, transform.position.y);
            flecha.gameObject.GetComponent<controlFlecha>().angle = angle;
            flecha.gameObject.GetComponent<controlFlecha>().velocidadInicial = VelocidadInicialFlecha;
            flecha.gameObject.GetComponent<controlFlecha>().damage = damageFlecha;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
           //flecha.gameObject.GetComponent<Collider2D>().isTrigger = false;
            cooldown = 0;
            Inventario.totalFlechas--; //Reduciendo las flechas del inventario
        }

    }


}
