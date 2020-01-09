using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controlara la animacion de ataque del personaje
public class Atacar : MonoBehaviour
{
    public Collider2D zonaAtaque;

    public int damage;

    private void Awake()
    {
        zonaAtaque.enabled = false;
    }
    

    void Update()
    {

        if(Estados.EstadoJugador == Estados.eEstadoJugador.Atacando)
        {
            zonaAtaque.enabled = true;
        }else
        {
            zonaAtaque.enabled = false;
        }
    }


}
