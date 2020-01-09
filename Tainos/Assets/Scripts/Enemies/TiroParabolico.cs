using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroParabolico : MonoBehaviour
{
    Vector3 posicion = Vector3.zero;
    Vector3 velocidad = new Vector3(10,0);

    public float damage;
    Vector3 distancia;

    GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        /// Ubica al jugador en el mapa y obtiene su trnasform
        jugador = GameObject.FindGameObjectWithTag("Player");

        /// Calcula la distancia entre el jugador y el objeto
        distancia = jugador.transform.position - transform.position;

        ///Se calcula el angulo de tiro
        //angulo = Vector3.Angle(jugador.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        ///la posicion y la direccion del objeto al moverse cuando se genera por su tirador
        posicion.x = distancia.normalized.x * velocidad.x * Time.deltaTime;
        posicion.y = (velocidad.y * Time.deltaTime) + Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2);
        transform.Translate(posicion);
        velocidad += Physics.gravity * Time.deltaTime;
    }

    /// <summary>
    /// Esta funcion hay que chequearla para que el jugador tambien pueda disparar
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            //other.GetComponent<CharacterMovement>().RecibirDamage(damage);

            ///se destruye el objeto que contiene el script
            Destroy(gameObject);
        }
        else if(other.tag == "Platform")
        {
            /// se destruye el objeto que contiene el script
            Destroy(gameObject);
        }
    }
}
