using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

   
    public enum eObjetoSeleccionado
    {
            Cuchillo,
            Arco,
            Lanza,
            Objeto
    }

    public static int totalFlechas = 5;
    public static int totalPociones;

    //Objetos
    public GameObject Pocion;
    public GameObject[] notas;

    //Capacidad de poder utilizar un espacio del inventario si se posee un objeto:
    public static bool SlotCuchillo = true;
    public static bool SlotArco = false;
    public static bool SlotLanza = false;
    public static bool SlotObjeto = false;
    
    public static eObjetoSeleccionado ArmaActual;


    void Update()
    {

        //Modificar los textos para ver el estado de los objetos
       

        if(totalPociones > 0)
        {
            SlotObjeto = true;
        }else
        {
            SlotObjeto = false;
        }
        
    }


}

