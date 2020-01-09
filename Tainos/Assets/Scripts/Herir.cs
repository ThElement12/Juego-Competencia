using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerirEnemigo : MonoBehaviour
{
    // Start is called before the first frame update

    public float tiempoEntreAtaques;
    public float tiempoAtaqueInicial;
    public int damage;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float rangoAtaque;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(tiempoEntreAtaques <= 0){

            if(Input.GetMouseButtonDown(0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,rangoAtaque,whatIsEnemies);

                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemigo>().takeDamage(damage);
                }
                
            
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
