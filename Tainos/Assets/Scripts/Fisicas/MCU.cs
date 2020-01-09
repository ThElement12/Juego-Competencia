using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MCU : MonoBehaviour
{
    	float velociadAngular; //w
	float angulo;
	public float Frecuencia = 10; //f

	public Vector3 velocidadLineal = Vector3.zero;
	public float aumentadorVelocidad = 0;

	Vector3 posicion;

	float densidad = 0.77f; /* kg/m^3 */ // suponiendo que el material es roble americano
	float volumen;
	public float masa;

    bool visible = false;
	public AudioSource SonidoChoque;



	/*public bool AFavorManecillas;
	public bool sentidoAsignado = false;*/

	//angulo = w / 2*pi
	//w = 2*pi/f

	// Start is called before the first frame update
	void Start()
    {
		//posicion = transform.position;

	}

    // Update is called once per frame
    void Update()
    {

        if (visible)
        {
            volumen = transform.localScale.x * transform.localScale.y * transform.localScale.x;
            masa = densidad * volumen;
            //Desplazar();
            Rotar();
            ActualizarPosicion();

        }
    }

	void Rotar()
	{
		velociadAngular = (2 * Mathf.PI * Frecuencia);

		angulo += velociadAngular * Time.deltaTime;

	}

    /*void Desplazar()
	{
		posicion.y += velocidadLineal.y * Time.deltaTime + (Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2));
		velocidadLineal.y = (Physics.gravity.y * Time.deltaTime) * (7 + aumentadorVelocidad); // multiplicar por 7 para que baje a velocidad natural
	}
*/
    private void OnBecameVisible()
    {
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
    }
    void ActualizarPosicion()
	{
		transform.localRotation = Quaternion.Euler(0, 0, angulo);
		//transform.position = posicion;
	}

	private void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponent<MeshRenderer>().enabled = false;
		if (other.transform.tag == "Player")
        {

		

		}
	}

}