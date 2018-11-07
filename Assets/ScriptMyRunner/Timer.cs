using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
public Text contador;
public float tiempo=60.0f;
public int tiempoI;

	// Use this for initialization
	void Start () {
		//contador.text=" "+tiempo.ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		tiempo-=Time.deltaTime;
		tiempoI=(int)tiempo;
		contador.text=" "+tiempoI.ToString();
	}
}
