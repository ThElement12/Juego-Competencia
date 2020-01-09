using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaControles : MonoBehaviour
{


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            Continuar();
        }
    }

    public void Continuar()
    {
        
        SceneManager.LoadScene("Mapa Principal");
    }
}
