using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT PARA CONTROLAR LO QUE DICEN LOS TEXTOS EN LA INTERFAZ DEL JUGADOR
public class ControlUI : MonoBehaviour
{
    
    public Image iconoFlechas;
    public Text txtIndiosRestantes;
    public Text txtTotalFlechas;

    public Text txtPocionesRestantes;
    
    void Update()
    {

        if (Inventario.SlotArco == false)
        {
            iconoFlechas.gameObject.SetActive(false);
            txtTotalFlechas.gameObject.SetActive(false);
        }
        else
        {
            txtTotalFlechas.gameObject.SetActive(true);
            iconoFlechas.gameObject.SetActive(true);
        }

        txtIndiosRestantes.text = Estados.indiosCapturados.ToString(); //mostrando los indios capturados
        txtTotalFlechas.text = Inventario.totalFlechas.ToString(); //
        txtPocionesRestantes.text = Inventario.totalPociones.ToString();

    }
}
