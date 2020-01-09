using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibre : MonoBehaviour
{

    Vector2 Movimiento;
    Vector2 Velocidad;
    Vector2 Aceleracion = new Vector2(0f, 1f);
    Vector2 posicionInicial;
    public float velCaida = 1f;
    bool caer;
    void Start()
    {
       
        posicionInicial = new Vector2(transform.position.x, transform.position.y);
        caer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (caer == true)
        {
            Movimiento.y = Velocidad.y * Time.deltaTime + (Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2));
            transform.Translate(Movimiento);
            Velocidad -= Aceleracion * Time.deltaTime * velCaida;
        }
        else if(caer == false)
        {
            Movimiento.y = 0;
            transform.Translate(Movimiento);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            caer = true;

        }

        if (collision.transform.tag == "Platform" || collision.transform.tag == "FSpikes")
        {
            gameObject.SetActive(false);
            caer = false;

        }
    }


    /// <summary>
    /// Reinicia el bloque a su posicion inicial
    /// </summary>
    public void Reiniciar()
    {
        caer = false;
        transform.position = posicionInicial;

        gameObject.SetActive(true);
    }



}