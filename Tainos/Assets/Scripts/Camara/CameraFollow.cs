using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private BoxCollider2D cameraBox;/// Collider 2D agregado a la camara 
    private Transform player;///Transform del player
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.aspect = 16.0f/9.0f;
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AspectRatioBoxChange();
        FollowPlayer();
       
        
    }

    /// Determina el size del collider la camara, dependiendo del aspect ratio

    void AspectRatioBoxChange()
    {   ///16:10 ratio
        if(Camera.main.aspect >= 1.6f && Camera.main.aspect < 1.9f)
        {
            cameraBox.size = new Vector2(14.56166f, 8.999232f);
        }
        //16:9 Ratio
        if (Camera.main.aspect >= 1.7f && Camera.main.aspect < 1.8f)
        {
            cameraBox.size = new Vector2(19.3796f, 10.89514f);
        }
        //5:4 Ratio
        if (Camera.main.aspect >= 1.25f && Camera.main.aspect < 1.3f)
        {
            cameraBox.size = new Vector2(11.38094f, 8.999232f);
        }
        //4:3 Ratio
        if (Camera.main.aspect >= 1.3f && Camera.main.aspect < 1.4f)
        {
            cameraBox.size = new Vector2(12.10797f, 8.999232f);
        }
        //3:2 Ratio
        if (Camera.main.aspect >= 1.5f && Camera.main.aspect < 1.6f)
        {
            cameraBox.size = new Vector2(13.60527f, 8.999232f);
        }

    }

    /// Simplemente funcion que hace que la camara siga al jugador
    void FollowPlayer()
    {
        GameObject boundary = GameObject.Find("Boundary");
        if (boundary)///Para no tener errores o warnings
        {
            Bounds bound = boundary.GetComponent<BoxCollider2D>().bounds;
            transform.position = new Vector3(Mathf.Clamp(player.position.x, bound.min.x + cameraBox.size.x / 2, bound.max.x - cameraBox.size.x / 2),
                                             Mathf.Clamp(player.position.y, bound.min.y + cameraBox.size.y/4, bound.max.y - cameraBox.size.y/4),
                                             transform.position.z);
        }

    }
}
