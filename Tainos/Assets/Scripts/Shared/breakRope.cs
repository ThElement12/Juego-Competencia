using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakRope : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject myBoss;
    void Start()
    {
        myBoss = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Flecha"))
        {
            /*
            transform.parent = null;
            GetComponent<FixedJoint2D>().enabled = false;
            /**/
            myBoss.transform.GetChild(myBoss.transform.childCount - 1).parent = null;
            myBoss.transform.GetChild(myBoss.transform.childCount - 1).GetComponent<FixedJoint2D>().enabled = false;
              
        }
    }
}
