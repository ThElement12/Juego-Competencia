using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingEnemyscript : MonoBehaviour
{
    // Start is called before the first frame update
    public float life;
    void Start()
    {
        //life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            life -= 0.1f;
        }
    }
}
