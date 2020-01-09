using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject[] Objetos;
    
    //Tipos de objetos a lootear
    GameObject Flecha;
    GameObject Pocion;
    GameObject ObjetoLooteado;


    public void getLoot()
    {
        if(Objetos.Length == 1)
        {
            ObjetoLooteado = Objetos[0];
        }
        else
        {
            ObjetoLooteado = Objetos[Random.Range(0, 5)]; //Los objetos salen con Probabilidades
        }

        if (ObjetoLooteado.tag == "Flecha" && Inventario.SlotArco == true) //si se ha desbloqueado el arco, los enemigos podrian lootear flechas
        {
            Instantiate(ObjetoLooteado, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ObjetoLooteado.GetComponent<Collider2D>().isTrigger = false;
        }

        if (ObjetoLooteado.tag == "Pocion") //looteando pociones
        {
            Instantiate(ObjetoLooteado, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ObjetoLooteado.GetComponent<Collider2D>().isTrigger = false;
        }
        if (ObjetoLooteado.tag == "desbloqueoArco") //looteando pociones
        {
            Instantiate(ObjetoLooteado, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }



    }



}
