using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float Velocidad = 0;
    private float tempVel = 0f; //para guardar la velocidad inicial digitada 
    public Animator animator;
    private float movHorizontal = 0f; //parametro para hacer transicion entre la animacion iddle y caminar
    private float movVertical = 0f;
    private float runSpeed = 2f;


    void Start()
    {
        
        animator = transform.GetComponent<Animator>();
        tempVel = Velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        //CONTROLANDO LAS ANIMACIONES
        movHorizontal = Input.GetAxisRaw("Horizontal") * runSpeed ;
        animator.SetFloat("speedX",Mathf.Abs(movHorizontal));

        movVertical = Input.GetAxisRaw("Vertical") * runSpeed;
        animator.SetFloat("speedY",Mathf.Abs(movVertical));

        if(Input.GetKey(KeyCode.A)){
            animator.SetBool("teclaIzquierda",true);
            animator.SetBool("teclaDerecha",false);
            animator.SetBool("teclaArriba",false);
            animator.SetBool("teclaAbajo",false);
         

        }
        else if(Input.GetKey(KeyCode.D)){
            animator.SetBool("teclaIzquierda",false);
            animator.SetBool("teclaDerecha",true);
            animator.SetBool("teclaArriba",false);
            animator.SetBool("teclaAbajo",false);
  
            // animator.SetFloat("speed",0);
        }
        else if(Input.GetKey(KeyCode.W)){
            animator.SetBool("teclaIzquierda",false);
            animator.SetBool("teclaDerecha",false);
            animator.SetBool("teclaArriba",true);
            animator.SetBool("teclaAbajo",false);
            
        }
        else if(Input.GetKey(KeyCode.S)){
            animator.SetBool("teclaIzquierda",false);
            animator.SetBool("teclaDerecha",false);
            animator.SetBool("teclaArriba",false);
            animator.SetBool("teclaAbajo",true);
            
        }

           moverse();
       
      
    }

    void moverse(){
        gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * Velocidad * Time.deltaTime);
       
       //Sprintear
       if(Input.GetKey(KeyCode.LeftShift)){
           Velocidad = 12; //velocidad de corrida
       }else{
           Velocidad = tempVel; //velocidad normal caminando
       }
    }
}
