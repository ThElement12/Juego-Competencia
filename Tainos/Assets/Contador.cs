using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//SCRIPT SIMPLE PARA CONTAR EL TIEMPO DE LA PANTALLA DE EPILOGO PARA SABER CUANDO PASAR A LOS CREDITOS
public class Contador : MonoBehaviour
{
    float contador;
    SceneManager escena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
   
        
        if(contador > 51f)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
