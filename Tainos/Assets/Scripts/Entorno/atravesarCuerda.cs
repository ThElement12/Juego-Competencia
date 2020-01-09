using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atravesarCuerda : MonoBehaviour
{
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
        if(collision.gameObject.tag == "Player")
        {
           gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        if(collision.gameObject.tag == "Flecha")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player")
        {
           gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    
    }

   private void OnTriggerExit2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player")
        {
           gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    
    }


}
