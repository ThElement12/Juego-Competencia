using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    Animator salto_anim;
    bool enTierra; //Para que el jugador no salte en el aire

    // Start is called before the first frame update
    void Start()
    {
        salto_anim = transform.GetComponent<Animator>();
        enTierra = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && enTierra == true)
        {
            enTierra = false;
            transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            salto_anim.SetBool("saltar", true);
           
        }
        

    }

    private void FixedUpdate()
    {
        //salto_anim.SetBool("saltar", false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        salto_anim.SetBool("saltar", false);
        enTierra = true;
    }
}
