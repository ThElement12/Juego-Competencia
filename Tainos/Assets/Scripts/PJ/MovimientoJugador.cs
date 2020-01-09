using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    float velocidad = 4;
    Vector2 movimiento = Vector2.zero;
    Rigidbody2D rigidbody;
    Animator Animator;

    bool isShooting;
    float cooldownSalto;
    float movimientoEscalera; //variable para detectar si se esta moviendo por la escalera para realizar esa animacion. Si es 0, 
                              //solamente estara la animacion del personaje enganchandose en la escalera

    bool isOnStair = false;
    bool isOnAir = false;
    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody2D>();
       Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSalto += Time.deltaTime;
      
        //Condicion inicial para evitar que el jugador se mueva si esta disparando una flecha
        /*  if(estadosJugador.EstadoArco == Estados.eEstadoArco.Disparando || estadosJugador.EstadoArco == Estados.eEstadoArco.Apuntando )
          {
              isShooting = true;
          }else
          {
              isShooting = false;
          }*/

        //Saltando
        if(Estados.EstadoJuego == Estados.eEstadoJuego.Play && Estados.EstadoAccion == Estados.eEstadoAccionJugador.Nada)
        {
        
            if ((Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Jump")) && (!isOnAir && !isOnStair  && cooldownSalto > 1.2f))
            {
                rigidbody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);///Saltar con Space
                isOnAir = true;
                cooldownSalto += Time.deltaTime;
                cooldownSalto = 0;
            }

            ///determinar la direccion del personaje para realizar rotacion del cuerpo
            if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("JoystickHorizontal") < 0)
            {
                transform.rotation = new Quaternion(0, -180f, 0, 0);
                movimiento = new Vector2(velocidad * Time.deltaTime, 0);
                Animator.SetBool("mover", true);
                Animator.SetFloat("speed", 1);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("JoystickHorizontal") > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                movimiento = new Vector2(velocidad * Time.deltaTime, 0);
                Animator.SetBool("mover", true);
                Animator.SetFloat("speed", 1);
            }
            else
            {
                movimiento = Vector2.zero;
                Animator.SetBool("mover", false);
                Animator.SetFloat("speed", 0);
            }




            if (isOnStair)//SI ESTA EN UNA ESCALERA
            {
                //Okay, captar el movimiento en la escalera:
                movimientoEscalera = Input.GetAxisRaw("Vertical");

                movimiento.y = movimientoEscalera * velocidad * Time.deltaTime;

                if (movimientoEscalera == 0) //si esta en la escalera pero no se esta moviendo:
                {
                    Animator.SetBool("isOnStair", true);
                    Animator.SetBool("isOnStairMoving", false);
                }
                if (movimientoEscalera > 0 || movimientoEscalera < 0) //Si esta en la escalera y se esta moviendo:
                {
                    Animator.SetBool("isOnStair", false);
                    Animator.SetBool("isOnStairMoving", true);
                }
            }
            else
            {
                //Cuando el personaje ya no esta en la escalera:
                Animator.SetBool("isOnStair", false);
                Animator.SetBool("isOnStairMoving", false);


            }

            //  if(isShooting == false)
            //  {
            transform.Translate(movimiento);
            //  }
            Animator.SetBool("saltar", isOnAir);

        }

            


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Platform")
        {
            isOnAir = false;
        }
        if(collision.gameObject.tag == "bloqueRoto")
        {
            cooldownSalto = 4;
            isOnAir = false;
        }
        
        if(collision.gameObject.tag == "Pared" || collision.gameObject.tag == "Techo")
        {
            isOnAir = false;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "Escalera")
        {
            isOnStair = true;
            Animator.SetBool("saltar", false);
            rigidbody.gravityScale = 0;
            rigidbody.velocity = Vector2.zero;
        }
         if(collision.gameObject.tag == "Suelo")
        {
            isOnStair = true;
         
        }
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Escalera")
        {
            isOnStair = false;
            rigidbody.gravityScale = 1;

        }
        if(collision.gameObject.tag == "Pared" || collision.gameObject.tag == "Techo")
        {
            isOnAir = false;
        }
    }
}
