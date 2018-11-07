using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aGameOver : MonoBehaviour {

public GameObject camaraGameOver;
public GameObject noMostrar;
public GameObject personaje;
public Text contadorResultado;
public Text win;
public Text contador;
public Text resultado;
public Text score;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(contador.text==" 0"){
			camaraGameOver.SetActive(true);
			noMostrar.SetActive(false);
			personaje.SetActive(false);
			resultado.text=contadorResultado.text;
			//score.text=int.Parse(score.text)+int.Parse(resultado.text);
		}

	}
	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.CompareTag("Player")){
			win.text=("YOU WIN");
			camaraGameOver.SetActive(true);
			noMostrar.SetActive(false);
			personaje.SetActive(false);
			resultado.text=contadorResultado.text;
		}
}
}
