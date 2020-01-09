using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerirJugador : MonoBehaviour
{
    // Start is called before the first frame update

    public float tiempoEntreAtaques;
    public float tiempoAtaqueInicial;
    public int damage;

    public Transform attackPos;
    public LayerMask whatIsJugador;
    public float rangoAtaque;

  //  GameObject jugador;

    void Start()
    {
    //    jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if(tiempoEntreAtaques <= 0){

          
            Collider2D[] Jugador = Physics2D.OverlapCircleAll(attackPos.position,rangoAtaque,whatIsJugador);

            for(int i = 0; i < Jugador.Length; i++)
            {
                 Jugador[i].GetComponent<Jugador>().takeDamage(damage);
           
            }
            
            tiempoEntreAtaques = tiempoAtaqueInicial;


        }else{
            tiempoEntreAtaques -= Time.deltaTime;
        }

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,rangoAtaque);
    }



}
