using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRU : MonoBehaviour
{
    Vector3 Movimiento;
    public float velocidad;
    public int direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento.x = direccion * (velocidad) * Time.deltaTime;
        transform.Translate(Movimiento);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        //Cuando la bola choca con el jugador o con el primer jefe
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Jugador>().takeDamage(15);
            Destroy(gameObject);
        }
        if(collision.transform.tag == "Pesado" || collision.transform.tag == "Boss1" || collision.transform.tag == "BOSS2")
        {
            if(collision.gameObject.GetComponent<Animator>().GetBool("isAttacking")/*!collision.gameObject.GetComponent<Animator>().GetBool("isMoving") && !collision.gameObject.GetComponent<Animator>().GetBool("iddle")*/)
            {
                collision.gameObject.GetComponent<Enemigo>().takeDamage(15);
                Destroy(gameObject);
            }else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

}
