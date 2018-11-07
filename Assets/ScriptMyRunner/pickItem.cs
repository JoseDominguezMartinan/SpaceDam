using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickItem : MonoBehaviour {
// este script hace que el gameobject que lo tiene sea destruido si colisiona con el componente con etiqueta player

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.CompareTag("Player")){
			Destroy(gameObject);

		}
	}
}
