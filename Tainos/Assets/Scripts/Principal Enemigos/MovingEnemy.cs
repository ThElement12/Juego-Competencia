using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*SCRIPT PARA EL MOVIMIENTO DE LOS ENEMIGOS EN UN RANGO */
public class MovingEnemy : MonoBehaviour
{

    float direccionMovimiento = 1f;
    SpriteRenderer sprite;
    public float limiteMovimientoIzquierdo;
    public float limiteMovimientoDerecho;
    Estados Estados;

    Animator animator; //se usa el animator para ver si el personaje esta en la animacion de moverse

    public float velocidadMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).localPosition = new Vector2(1f, 0);
        animator = transform.gameObject.GetComponent<Animator>();
        sprite = transform.gameObject.GetComponent<SpriteRenderer>();
        sprite.flipX = true;
        Estados = GameObject.FindGameObjectWithTag("GameController").GetComponent<Estados>();


    }

    
    void Update()
    {
        if (Estados.EstadoJuego == Estados.eEstadoJuego.Play){

    
         //Si la animacion de movimiento esta activa, moverse
          if(animator.GetBool("isMoving"))
          {
               
                 transform.Translate(new Vector3(velocidadMovimiento * direccionMovimiento,0));
            
                if(transform.position.x > (limiteMovimientoDerecho) && direccionMovimiento > 0)
                {
                    transform.GetChild(1).localPosition = new Vector2(-1f, 0);
                    direccionMovimiento = -1f;
                    sprite.flipX = false;
                
                    
                }
                if (transform.position.x < (limiteMovimientoIzquierdo) && direccionMovimiento < 0)
                {

                    transform.GetChild(1).localPosition = new Vector2(1f, 0);
                    direccionMovimiento = 1f;
                    sprite.flipX = true;
      
                }
              
           
          }
          else
          {
                transform.Translate(new Vector3(0,0));
          }
        }  
    }
}
