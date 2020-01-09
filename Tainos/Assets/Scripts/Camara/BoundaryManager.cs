using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private BoxCollider2D managerBox; //Collider del boundaryManager
    private Transform player; /// Transform del jugador
    public GameObject boundary;/// El boundary(perimetro) En si
    public GameObject[] bloquesEnElArea;////Bloques fragiles que se encuentran en el area del boundary
    public GameObject[] lucesEnElArea;////Luces que se encunetran en el area del boundary

    // Start is called before the first frame update
    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageBoundary();
        
    }
    void ManageBoundary()
    {   ///Activa o desactiva el boundary dependiendo de en cual manager el jugador se encuentre, asi no hay errores al llamar un boundary en el script de la 
        ///camara
        if(managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x &&
            managerBox.bounds.min.y < player.position.y && player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);

        }
        else
        {
            
            foreach (GameObject bloque in bloquesEnElArea)
            {
                bloque.GetComponent<CaidaLibre>().Reiniciar();
            }

            boundary.SetActive(false);
        }


    }
    
}
