using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    GameObject Jugador;
    public float velocidad;
    float posY;
    Estados Estados;
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
        posY = transform.position.y;
        Estados = GameObject.FindGameObjectWithTag("GameController").GetComponent<Estados>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Estados.EstadoJuego == Estados.eEstadoJuego.Play)
        {
            transform.position = Vector2.MoveTowards(transform.position, Jugador.transform.position, velocidad * Time.deltaTime);
        }
    }
}
