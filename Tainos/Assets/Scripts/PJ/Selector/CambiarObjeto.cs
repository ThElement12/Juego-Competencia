using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarObjeto : MonoBehaviour
{
    public int contadorJoystick; //contador de veces que el jugador pisa R1 para cambiar un objeto
    public GameObject[] Items;
    //el estado desde desde aqui
    ControlAnimAtaque objetoJugador;
    
    void Start()
    {
        objetoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlAnimAtaque>();
       
    }


    void Update()
    {
        if(Input.GetButtonDown("R1"))
        {
            if(Inventario.SlotArco == true && Inventario.SlotLanza == true)
            {
                contadorJoystick++;
            }else if(Inventario.SlotArco == true && Inventario.SlotLanza == false)
            {
                if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Arco)
                {
                    contadorJoystick += 2;
                }
                if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Cuchillo)
                {
                    contadorJoystick++;
                }
                  if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Objeto)
                {
                    contadorJoystick++;
                }
            }
            if(Inventario.SlotArco == false && Inventario.SlotLanza == false)
            {
                contadorJoystick += 3;
            }

            if(contadorJoystick > 3)
            {
                contadorJoystick = 0;
            }
        }
        else if(Input.GetButtonDown("L1"))
        {
            if(Inventario.SlotArco == true && Inventario.SlotLanza == true)
            {
                contadorJoystick--;
            }else if(Inventario.SlotArco == true && Inventario.SlotLanza == false)
            {
                if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Objeto)
                {
                    contadorJoystick -= 2;
                }
                if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Arco)
                {
                    contadorJoystick--;
                }
                  if(Inventario.ArmaActual == Inventario.eObjetoSeleccionado.Cuchillo)
                {
                    contadorJoystick--;
                }
            }
            if(Inventario.SlotArco == false && Inventario.SlotLanza == false)
            {
                contadorJoystick -= 3;
            }

            if(contadorJoystick < 0)
            {
                contadorJoystick = 3;
            }
        }
       
       if(Input.GetKeyDown(KeyCode.Alpha1))
       {
           contadorJoystick = 0;
       }


       if(Input.GetKeyDown(KeyCode.Alpha2))
       {
           contadorJoystick = 1;
       }


       if(Input.GetKeyDown(KeyCode.Alpha3))
       {
           contadorJoystick = 2;
       }


       if(Input.GetKeyDown(KeyCode.Alpha4))
       {
           contadorJoystick = 3;
       }


        //Debug.Log(contadorJoystick);

        //Uso de lanza al presionar el numerico 1
        if ((Input.GetKeyDown(KeyCode.Alpha1) || contadorJoystick ==0) && Inventario.SlotCuchillo == true)
        {
            Inventario.ArmaActual = Inventario.eObjetoSeleccionado.Cuchillo;
            Seleccionar(0);
            objetoJugador.indiceInventario = 1;
        }

        //Uso de arco al presionar el numerico 2
        if ((Input.GetKeyDown(KeyCode.Alpha2) || contadorJoystick == 1) && Inventario.SlotArco == true)
        {
            Inventario.ArmaActual = Inventario.eObjetoSeleccionado.Arco;
            objetoJugador.indiceInventario = 3;
            Seleccionar(1);
        }

        //Uso de lanza al presionar el numerico 3
        if ((Input.GetKeyDown(KeyCode.Alpha3) || contadorJoystick == 2) && Inventario.SlotLanza == true)
        {
            Inventario.ArmaActual = Inventario.eObjetoSeleccionado.Lanza;
            objetoJugador.indiceInventario = 2;
            Seleccionar(2);
        }

        //Uso de objeto especial al presionar el numerico 4
        if ((Input.GetKeyDown(KeyCode.Alpha4) || contadorJoystick == 3) && Inventario.SlotObjeto == true)
        {
            Inventario.ArmaActual = Inventario.eObjetoSeleccionado.Objeto;
            Seleccionar(3);
        }

//        Debug.Log(Selector.ArmaActual);

    }
    void Seleccionar(int index)
    {
        for(int i = 0; i < Items.Length; i++)
        {
            if(i == index)
            {
                Items[i].GetComponent<Image>().color = new Color(255, 0, 0);
            }
            else
            {
                Items[i].GetComponent<Image>().color = new Color(75, 75, 75,255);

            }
        }
    }
}
