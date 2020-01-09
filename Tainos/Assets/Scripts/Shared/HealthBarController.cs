using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 localScale;
    GameObject myParent;
    Jugador jugador;

    public float factorSize; //un valor que se usara para multiplicar la escala y que no se vea demasiado ancha la barra

    public enum eObjetoQueLoUsa
    {
        Enemigo,
        RangeEnemy
    }
    //Indicar que objeto sera el que su vida sea controlada
    public eObjetoQueLoUsa ObjetoQueLoUsa;

    void Start()
    {
        localScale = transform.localScale;
        myParent = transform.parent.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjetoQueLoUsa == eObjetoQueLoUsa.Enemigo)
        {
            localScale.x = myParent.GetComponent<Enemigo>().vida * factorSize;
            transform.localScale = localScale;

        } else if(ObjetoQueLoUsa == eObjetoQueLoUsa.RangeEnemy)
        {
            localScale.x = myParent.GetComponent<RangeEnemyControl>().vida * factorSize;
            transform.localScale = localScale;
        }
        
    }
}
