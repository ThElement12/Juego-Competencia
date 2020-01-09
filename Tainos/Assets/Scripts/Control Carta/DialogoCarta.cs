using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DialogoCarta : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index = 0;
    public float typingSpeed;
    bool cartaAbierta;


    public GameObject continueButton;
    public GameObject carta;

    public bool final = false;
    // Start is called before the first frame update
    void Start()
    {
        cartaAbierta = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (cartaAbierta)
        {
            if (textDisplay.text == sentences[index])
            {
                
                continueButton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Interactuar"))
                {
                   NextSentece();
                }

            }
        }
        
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentece()
    {
        continueButton.SetActive(false);
        if (index == sentences.Length - 1)
        {
            Estados.EstadoJuego = Estados.eEstadoJuego.Play;
            carta.SetActive(false);
            Estados.EstadoAccion = Estados.eEstadoAccionJugador.Nada;
            cartaAbierta = false;
            if (final)
            {
                SceneManager.LoadScene("Epilogo");
                
            }

        }
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
    /// <summary>
    /// Funcion de abrir carta
    /// Sirve para abrir una nueva carta cuando el jugador abre un cofre
    /// </summary>
    /// <param name="oraciones">
    /// Los textos que va a mostrar la carta
    /// </param>
    public void AbrirCarta(string [] oraciones)
    {
       
        carta.SetActive(true);
        sentences = (string[])oraciones.Clone();
        Estados.EstadoAccion = Estados.eEstadoAccionJugador.Leyendo;
        index = 0;
        cartaAbierta = true;
        StartCoroutine(Type());
        
    }
}

