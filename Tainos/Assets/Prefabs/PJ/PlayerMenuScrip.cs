using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuScrip : MonoBehaviour
{
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("mover", true);
        myAnimator.SetFloat("speed", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
