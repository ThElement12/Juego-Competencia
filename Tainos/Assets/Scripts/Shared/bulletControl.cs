using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Jugador>().takeDamage(damage);
            Destroy(gameObject);
        }

        else if (collision.tag.Equals("Platform") || collision.tag.Equals("Techo") || collision.tag.Equals("Pared") || collision.tag.Equals("Enemigo") || collision.tag.Equals("Cuerda"))
        {
            Destroy(gameObject);
        }
    }
}
