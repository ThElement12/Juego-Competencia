using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFallControllerSound : MonoBehaviour
{
    public AudioSource fallSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Platform"))
        {
            fallSound.Play();
        }
    }
}
