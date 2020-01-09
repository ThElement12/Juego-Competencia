using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSpikesDamage : MonoBehaviour
{
    public int damage;
    GameObject player;
    float coolDownDamage;
    float alturaJugador;
    float distanciaJugador;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        alturaJugador = Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y);
        distanciaJugador = Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            player.GetComponent<Jugador>().takeDamage(damage);
        }
        if(collision.tag.Equals("BOSS2") && alturaJugador < 2 && distanciaJugador < 15)
        {
            collision.GetComponent<Enemigo>().takeDamage(10);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if(coolDownDamage > 1.3f)
            {
                player.GetComponent<Jugador>().takeDamage(damage);
                coolDownDamage = 0f;
            }else
            {
                coolDownDamage += Time.deltaTime;
            }
        }
    }
}
