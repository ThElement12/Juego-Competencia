using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlFlecha : MonoBehaviour
{

    Vector3 movimiento;
    public Vector3 velocidadInicial;
    Vector3 velocidad;
    
    public float angle;
    public int damage;
    bool enPiso;
    
    void Start()
    {
        //Direccion de la flecha al ser disparada
        if(GameObject.FindGameObjectWithTag("Player").transform.rotation.y < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
                transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        gameObject.GetComponent<Collider2D>().isTrigger = true;
        movimiento.x = 0;
        movimiento.y = 0;
        velocidad = velocidadInicial;
        
    }

    // Update is called once per frame
    void Update()
    {
            //Movimiento en parabolico de la flecha
            movimiento.x = (velocidad.x * Mathf.Cos(angle * Mathf.Deg2Rad)) * Time.deltaTime;
            movimiento.y = ((velocidad.y * Mathf.Sin(angle * Mathf.Deg2Rad)) * Time.deltaTime) - ((Physics.gravity.y * Mathf.Pow(Time.deltaTime,2)) / 2);

           
            if(enPiso != true)
            {
                 //perdida de altura
                velocidad.y -= 0.1f;

                //desplazamiento de la flecha
                transform.Translate(movimiento);              
        
            }
    }

    void OnCollisionEnter2D(Collision2D objeto)
    {

        if(objeto.transform.tag == "EnemigoNormalCuchillo" || objeto.transform.tag == "EnemigoMachete" || objeto.otherCollider.tag == "Boss1")
        {
            objeto.transform.GetComponent<Enemigo>().takeDamage(damage);
            Destroy(gameObject);
        }

        if (objeto.transform.tag == "Platform")
        {
            enPiso = true;
        }
        else if(objeto.transform.tag == "Pared")
        {
            Destroy(gameObject);
        }
        else if(objeto.transform.tag == "Player")
        {
            Inventario.totalFlechas++;
            //gameObject.GetComponent<Collider2D>().isTrigger = false; //volviendo la flecha trigger para que no se quede pegada al jugador al ser disparada
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventario>().totalFlechas++;
            Destroy(gameObject);
        }
        
        //Rompiendo cuerdas
        if (objeto.transform.tag == "Cuerda")
        {
            Destroy(objeto.gameObject);
        }
             
    }

    //Cuando la flecha sale del jugador se hace fisica para chocar con el suelo
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            transform.GetComponent<Collider2D>().isTrigger = false;        
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        //Rompiendo cuerdas
        if (other.transform.tag == "Cuerda")
        {
            Destroy(other.gameObject);
        }
    }

}
