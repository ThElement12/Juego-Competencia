using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo: MonoBehaviour
{
    public TextMeshProUGUI display;

    [TextArea(3,10)] //ampliando el area de escritura de frases en el editor
    public string[] frases;

    public int index;
    public float velEscritura;
    public GameObject botonContinuar;
    GameObject objetoPadre;

    private void Start()
    {
        StartCoroutine(Escribir());
    }

    private void Update()
    {
        if (display.text == frases[index])
        {
            botonContinuar.SetActive(true);
        }   
    }

    public IEnumerator Escribir()
    {
        foreach(char letra in frases[index].ToCharArray())
        {
            display.text += letra;
            yield return new WaitForSeconds(velEscritura);
        }
    }

    public void siguienteFrase()
    {
        botonContinuar.SetActive(false);

        if (index < frases.Length - 1)
        {
            index++;
            display.text = "";
            StartCoroutine(Escribir());
        }else
        {
            display.text = "";

            botonContinuar.SetActive(false);
            //transform.parent.gameObject.SetActive(false);
          
        }
    }

}
