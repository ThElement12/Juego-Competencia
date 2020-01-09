using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    public GameObject myChild;
    public float speed;
    Vector3 position = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        position.x = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(position);
        switch (tag)
        {
            case "trees_1":
                if (transform.position.x < -36.49775f)
                {
                    Instantiate(myChild, new Vector3(37.70225f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case "trees_2":
                if (transform.position.x < -33.62487f)
                {
                    Instantiate(myChild, new Vector3(37.70225f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case "grass":
                if (transform.position.x < -33.5405f)
                {
                    Instantiate(myChild, new Vector3(37.6595f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
        }
        
    }
}
