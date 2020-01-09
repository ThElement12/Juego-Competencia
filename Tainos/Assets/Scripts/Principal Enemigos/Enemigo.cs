using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public float vidaInicial;
    public float vida = 100;
    public int attackDamage = 1;
    public float speed = 2;

    public bool attack = false;
    public bool moverse = true;
    public float RangoAlertaJugador;
    
    public float velocidadDeAtaque = 1f;
    float coolDownAtaque;
    Vector2 attackPosition;
    Animator animator;
    Transform Target;
    float step;
    float distanciaJugador;
    float alturaJugador;
    public float rangoAtaque;
    
    GameObject jugador;
    Vector2 posicionInicial;

    private void Start()
    {
        vidaInicial = vida;
        jugador = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        Target = jugador.transform;
        posicionInicial = new Vector2(transform.position.x, transform.position.y);

    }
    private void Update()
    {
        distanciaJugador = Mathf.Abs(jugador.transform.position.x -  transform.position.x);
        alturaJugador = Mathf.Abs(jugador.transform.position.y - transform.position.y);
        animator.SetFloat("velAtaque", velocidadDeAtaque);
        animator.SetFloat("distanciaJugador", distanciaJugador);
        animator.SetFloat("alturaJugador", alturaJugador);

        if (Estados.EstadoJuego == Estados.eEstadoJuego.Play)
        {
            if (vida == 0)
            {
                attack = false;
                gameObject.SetActive(false);
            }

            ControlEnemigos();
        }     

    }
    public void Reiniciar()
    {
        gameObject.transform.position = posicionInicial;
        gameObject.SetActive(true);
    }

    void ControlEnemigos()
    {
        if (gameObject.tag == "EnemigoNormalCuchillo")
        {
            EnemigoNormalCuchillo();
        }


        if (gameObject.tag == "EnemigoMachete")
        {

            if (distanciaJugador < 4 && alturaJugador < 2)
            { 
                AtaqueEnemigoMachete();
            }
        }

        if (gameObject.tag == "Pesado" || gameObject.tag == "Boss1")
        {
            if(alturaJugador < 2)
            {
                ControlPesado();
            }
        }

        if(gameObject.tag == "BOSS2")
        {
           if(alturaJugador < 2)
            {
                ControlPesado();
            }
        }


        RotacionEnemigo();
    }


    void RotacionEnemigo()
    {
        //Condiciones para hacer que el enemigo "vea" en todo momento al jugador cuando este cerca
        if (transform.position.x - Target.transform.position.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);        
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);    
        }
        ///////////////////////////////////////////////////////////////

    }


    #region EnemigoNormalCuchillo
 
    void EnemigoNormalCuchillo()
    {

        if (distanciaJugador <=RangoAlertaJugador && alturaJugador < 2)
        {
            transform.position = new Vector2(Vector2.MoveTowards(transform.position,jugador.transform.position, step).x, transform.position.y);
            animator.SetBool("isMoving", true);
            animator.SetBool("iddle", false);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("iddle", true);
        }
        if(distanciaJugador <= rangoAtaque && alturaJugador < 0)
        {
            // transform.position = new Vector2(Vector2.MoveTowards(transform.position, Target.position, step).x, transform.position.y);
            animator.SetBool("isAttacking", true);
            animator.SetBool("iddle", false);
            //animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("iddle", true);
        }
        step = speed * Time.deltaTime;
        
    }


    #endregion

    #region EnemigoMachete
    void AtaqueEnemigoMachete()
    {

        if (distanciaJugador > rangoAtaque)
        {
            animator.SetBool("isAttacking", false);
        }
        else
        {
            if (coolDownAtaque < 0)
            {
                coolDownAtaque = velocidadDeAtaque;
                animator.SetBool("isAttacking", true);
                
            }
            else
            {
                coolDownAtaque -= Time.deltaTime;
                GetComponent<Animator>().SetBool("isAttacking", false);
            }

        }

    }

    #endregion

    #region PESADO
    void ControlPesado()
    {
        
        if (distanciaJugador <= RangoAlertaJugador)
        {

            transform.position = new Vector2(Vector2.MoveTowards(transform.position, jugador.transform.position, step).x, transform.position.y);
            
            animator.SetBool("iddle", false);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("iddle", true);
        }

        if (distanciaJugador <= rangoAtaque)
        {
            //attackSound.Play();
            // transform.position = new Vector2(Vector2.MoveTowards(transform.position, Target.position, step).x, transform.position.y);
            animator.SetBool("isAttacking", true);
            animator.SetBool("iddle", false);
            animator.SetBool("isMoving", false);
        }
        else
        {
            coolDownAtaque += Time.deltaTime;
            if(coolDownAtaque > 2f)
            {
                animator.SetBool("isAttacking", false);
            }
            animator.SetBool("isMoving", true);

        }
        step = speed * Time.deltaTime;

    }
    #endregion


    public void takeDamage(float damage)
    {
        vida = Mathf.Clamp(vida - damage, 0, 100);
        if(vida == 0)
        {
            gameObject.GetComponent<Loot>().getLoot();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Evitando que  el enemigo choque con otros
        if(collision.transform.tag == "EnemigoNormalCuchillo" || collision.transform.tag == "EnemigoMachete")
        {
            transform.GetComponent<Collider2D>().enabled = false;
        }else
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
        if(collision.transform.tag == "Flecha")
        {
            takeDamage(collision.transform.GetComponent<controlFlecha>().damage);
        }
    }
    
}
