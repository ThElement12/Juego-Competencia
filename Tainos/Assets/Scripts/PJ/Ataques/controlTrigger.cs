using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTrigger : MonoBehaviour
{

    //LA FUNCION PRINCIPAL DE ESTE SCRIPT ES QUE CONTROLARA QUE PASARA CON EL COLLIDER "AttackTrigger" del jugador o enemigo


    public AudioSource audio;
    int damage;
    bool golpeRoca = false;
    

    void Start()
    {
        if (transform.parent.gameObject.tag != "Player" && transform.parent.gameObject.tag != "EnemigoRango")
        {
            damage = transform.parent.GetComponent<Enemigo>().attackDamage; //obteniendo la variable damage del script atacar 
        }
        if(transform.parent.gameObject.tag == "EnemigoRango")
        {
            damage = transform.parent.GetComponent<RangeEnemyControl>().bullet.GetComponent<bulletControl>().damage;
        }
        if (transform.parent.gameObject.tag == "Player")
        {
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Atacar>().damage; //obteniendo la variable damage del script atacar 
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Cuando el attack trigger le pertenece al jugador
        if(transform.parent.tag == "Player")
        {
            if (other.tag == "EnemigoNormalCuchillo" || other.tag == "EnemigoMachete")
            {
                other.transform.GetComponent<Enemigo>().takeDamage(damage);
            }
            if(other.tag == "EnemigoRango")
            {
                other.transform.GetComponent<RangeEnemyControl>().takeDamage(damage);
            }

            if (other.tag == "Roca")
            {
                other.transform.GetComponent<romperRoca>().recibirAtaque();
            }
             if (other.tag == "Cuerda")
            {
                Destroy(other.gameObject);
            }
            if(other.tag == "Pesado" && Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Cuchillo)
            {
                other.transform.GetComponent<Enemigo>().takeDamage(0);
            }
            if((other.tag == "Pesado"||other.tag == "EnemigoNormalCuchillo"||other.tag == "EnemigoMachete") && Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Lanza)
            {
                other.transform.GetComponent<Enemigo>().takeDamage(10);
            }
            if(other.tag == "BOSS2" && Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Lanza)
            {
                other.transform.GetComponent<Enemigo>().takeDamage(25);
            }
        }
        
        //Si el attack trigger le pertenece al enemigo
        if (other.tag == "Player")
        {
            audio.Play();
            other.GetComponent<Jugador>().takeDamage(damage);
            
        }

    }

   

}


