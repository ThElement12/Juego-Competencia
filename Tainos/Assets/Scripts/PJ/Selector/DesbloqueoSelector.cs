using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoSelector : MonoBehaviour
{
    
    public GameObject[] Slots;

    // Start is called before the first frame update
    void Start()
    {
        //Inventario.SlotArco = true;
       // Inventario.SlotLanza = true;
        //Inventario.SlotObjeto = true;
        //Inventario.totalPociones = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventario.SlotArco == true)
        {
            Slots[0].SetActive(true); //haciendo el arco visible
        }
        if (Inventario.SlotLanza == true)
        {
            Slots[1].SetActive(true); //haciendo la lanza visible
        }
        if (Inventario.SlotObjeto == true)
        {
            Slots[2].SetActive(true); //haciendo la pocion visible
        }else
        {
            Slots[2].SetActive(false); //Si no hay pociones, no se mostraran
        }
        
    }
}
