using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recogerLanza : MonoBehaviour
{

    //SCRIPT PARA RECOGER EL ARCO DEL SUELO Y DESBLOQUEARLO EN EL SELECTOR

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && !collision.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            //Desbloqueando en el inventario el arco

            Inventario.SlotLanza = true;

            Destroy(gameObject);
        }
    }

}
