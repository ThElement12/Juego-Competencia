using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextoAvisoAlJugador : MonoBehaviour
{
   
    public GameObject player;
    private static TextMesh Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMesh>();
        transform.position = new Vector2(player.transform.position.x, transform.position.y);
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2);
       
    }
    public static void SetTexto(string texto)
    {
        Text.text = texto;
    }
}
