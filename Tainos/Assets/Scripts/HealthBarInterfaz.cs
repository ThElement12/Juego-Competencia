using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarInterfaz : MonoBehaviour
{
    GameObject Jugador;
    float VidaJugador;
    Text textoVida;
    public GameObject vidaTexto;
    RectTransform transformInterfaz;
    // Start is called before the first frame update
    void Start()
    {
        transformInterfaz = GetComponent<RectTransform>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        textoVida = vidaTexto.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        VidaJugador = Jugador.GetComponent<Jugador>().vida;
        transformInterfaz.localScale = new Vector3(VidaJugador/100, transformInterfaz.localScale.y, transformInterfaz.localScale.z);
        textoVida.text = VidaJugador.ToString() + "%";
    }
}
