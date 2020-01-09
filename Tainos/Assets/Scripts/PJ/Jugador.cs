using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    
    public int vida;
    Inventario inventario;

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventario>();
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.GetComponent<Animator>().SetInteger("vida",vida);

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetButtonDown("Fire1"))
        {
            tomarPocion();
        }
        if(vida == 0)///Si el jugador muere, se carga el checkpoint
        {
            SaveState.LoadState();
        }
       

    }

    public void takeDamage(int damage)
    {
        vida = Mathf.Clamp(vida - damage, 0, 100);

    }

    public void tomarPocion()
    {
        if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Objeto && Inventario.totalPociones > 0 && vida < 100)
        {
            vida = Mathf.Clamp(vida + 25, 0, 100);
            Inventario.totalPociones--;
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Pocion")
        {
            if(inventario.Pocion == null) {

                inventario.Pocion = Instantiate(collision.gameObject);
                inventario.Pocion.SetActive(false);
            }
            Inventario.totalPociones++;

        Destroy(collision.gameObject);
        }
        
    }

}
