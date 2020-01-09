using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public float Velocidad = 1;
	public float limiteSuperior;
	public float limiteInferior;

	GameObject fondo2;

    // Start is called before the first frame update
    void Start()
    {
		//limiteSuperior = GameObject.Find("ReferenciaFondo").transform.localScale.y;
		limiteSuperior = 2f * Camera.main.orthographicSize;
		limiteInferior = limiteSuperior * -1;

    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.right * Velocidad * Time.deltaTime);

		//transform.position += new Vector3()

		if(transform.localPosition.x >= limiteSuperior)
		{
			transform.localPosition = new Vector3(limiteInferior, transform.localPosition.y, transform.localPosition.z);
		}
    }
}