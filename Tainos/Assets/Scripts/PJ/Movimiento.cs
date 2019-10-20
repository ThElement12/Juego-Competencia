using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float Velocidad = 0;
    public Animator animator;
    public SpriteRenderer sprite;
    private float movHorizontal = 0f; //parametro para hacer transicion entre la animacion iddle y caminar
    private float movVertical = 0f;
    private float runSpeed = 2f;


    void Start()
    {
        
        animator = transform.GetComponent<Animator>();
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //CONTROLANDO LAS ANIMACIONES
        movHorizontal = Input.GetAxisRaw("Horizontal") * runSpeed ;
        animator.SetFloat("speed",Mathf.Abs(movHorizontal));

        if(Input.GetKey(KeyCode.A)){
            animator.SetBool("mover",true);
            sprite.flipX = true;
        }

        if(Input.GetKey(KeyCode.D)){
            animator.SetBool("mover", true);
            sprite.flipX = false;
           // animator.SetFloat("speed",0);
        }

       
        
        moverse();
    
    }

    private void FixedUpdate()
    {
        //Default
        animator.SetBool("mover", false);
    }

    void moverse(){
      this.transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0) * Velocidad);
       
       //Sprintear
       if(Input.GetKey(KeyCode.LeftShift)){
           Velocidad = 0.1f; //velocidad de corrida
            animator.SetFloat("sprint", 1.2f); //acelerando animacion

        }
        else
        {
           Velocidad = 0.04f; //velocidad normal caminando
           animator.SetFloat("sprint", 1); //devolviendo animacion a su velocidad normal

        }
    }
}
