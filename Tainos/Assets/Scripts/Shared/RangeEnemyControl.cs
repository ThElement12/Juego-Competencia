using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyControl : MonoBehaviour
{
    public AudioSource attackSound;
    public float vidaInicial;
    public float vida;
    public float speed, detectionpos;
    public GameObject bullet;
    public bool attack;
    public Vector2 attackPosition;
    float alturaJugador;

    GameObject player;
    float velocity = 500.0f;
    float step = 0;
    bool hasAttacked = false, enter = true;
    int counter = 100;
    Animator myAnimation;
    Vector2 distance;

    Vector2 posicionInicial;

    void Start()
    {
        posicionInicial = new Vector2(transform.position.x, transform.position.y);
        player = GameObject.FindGameObjectWithTag("Player");
        myAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        alturaJugador = Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y);
        if(vida == 0)
        {
            gameObject.SetActive(false);
        }

        MovimientoEnemigo();
        ataqueEnemigo();
    }
    public void Reiniciar()
    {
        gameObject.transform.position = posicionInicial;
        gameObject.SetActive(true);
    }

    void ataqueEnemigo()
    {

        distance.x = Math.Abs(transform.position.x - player.transform.position.x);
        // si el jugador esta en la distancia de vision 
        if (distance.magnitude <= detectionpos && alturaJugador < 2)
        {
            //acercarse al juagador hasta que la posicion sea la minima para atacar
            if (distance.x > attackPosition.x && distance.y < attackPosition.y)
            {
                myAnimation.SetBool("isWalking", true);
                transform.position = new Vector3(Vector3.MoveTowards(transform.position, player.transform.position, step).x, transform.position.y, transform.position.z);
                enter = true;
            }
            // si es la posicion minima el enemigo empiza a atacar
            else if (distance.x <= attackPosition.x && distance.y <= attackPosition.y)
            {
                if (enter)
                {
                    attackSound.Play();
                    myAnimation.SetBool("isAttacking", true);
                    enter = false;
                }
                myAnimation.SetBool("isWalking", false);
                if (attack && !hasAttacked)
                {
                    var newBullet = Instantiate(bullet, gameObject.transform, false);
                    newBullet.transform.localPosition = new Vector3(-1.652f, 0.132f);

                    if (transform.rotation.y > -1)
                        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * velocity, player.transform.position.y - 2f));
                    else
                        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * velocity, player.transform.position.y - 2f));

                    newBullet.transform.parent = null;
                    //attackSound.Play();
                    myAnimation.SetBool("isAttacking", false);
                    hasAttacked = true;
                    counter = 100;
                }
                else if (hasAttacked && counter > 0)
                {
                    counter -= 1;
                }

                else if (hasAttacked && counter == 0)
                {
                    myAnimation.SetBool("isAttacking", true);
                    hasAttacked = false;
                }
            }
        }
        else
        {
            myAnimation.SetBool("isWalking", false);
            myAnimation.SetBool("isAttacking", false);
        }
    }

    void MovimientoEnemigo()
    {
        //si el jugador esta detras del enemigo
        if (transform.position.x - player.transform.position.x > 0)
        {
            if (tag == "EnemigoRango")

                transform.rotation = new Quaternion(0, 0, 0, 0);

            else
                transform.rotation = new Quaternion(0, -180.0f, 0, 0);
        }
        // si el enemigo esta detras del enemigo volteado
        else
        {
            if (tag == "EnemigoRango")
                transform.rotation = new Quaternion(0, -180.0f, 0, 0);

            else
                transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        step = speed * Time.deltaTime;
    }

    public void takeDamage(float damage)
    {
        vida = Mathf.Clamp(vida - damage, 0, 100);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Evitando que el enemigo choque con otros
        if (collision.transform.tag == "EnemigoNormalCuchillo" || collision.transform.tag == "EnemigoMachete")
        {
            transform.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
        if (collision.transform.tag == "Flecha")
        {
            takeDamage(collision.transform.GetComponent<controlFlecha>().damage);
        }
    }
}
