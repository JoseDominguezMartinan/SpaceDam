using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class recargarEscena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void reload(string nameEscena){
		SceneManager.LoadScene(nameEscena);
	}
	public void salir(){
		Application.Quit();
	}
}
