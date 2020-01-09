using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararCanon : MonoBehaviour
{
    public AudioSource attackSound;
    public GameObject prefabBolaCanon;
    public int DireccionDisparo;
    public int velocidadDisparo;
    public float tiempoEntreDisparos;
    GameObject bolaCanon;
 
    float contador;
    // Update is called once per frame
    void Update()
    {
        ///Si es visible o no, para mejorar el rendimiento
      
            contador += Time.deltaTime;
            if(contador > tiempoEntreDisparos)
            {
                Disparar();
                contador = 0;
            }

        

    }

    //Rutina para disparar el cañon cada cierto tiempo
    void Disparar()
    {
        attackSound.Play();
        bolaCanon = Instantiate(prefabBolaCanon);
        if(DireccionDisparo > 0)
        {
            bolaCanon.transform.position = new Vector3(transform.position.x + 1f, transform.position.y);
        }
        if (DireccionDisparo < 0)
        {
            bolaCanon.transform.position = new Vector3(transform.position.x - 1f, transform.position.y);
        }
        bolaCanon.GetComponent<MRU>().velocidad = velocidadDisparo;
        bolaCanon.GetComponent<MRU>().direccion = DireccionDisparo;


    }
  
}
