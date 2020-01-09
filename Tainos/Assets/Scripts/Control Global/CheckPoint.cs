using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT PARA EL GUARDADO DE ESTADO DE JUEGO PARA EL MOMENTO DE RESPAWN
public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SaveState.saveState(gameObject);
            print("CheckPoint guardado con exito");
            gameObject.SetActive(false);

        }
        
    }
}
