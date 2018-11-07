using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour {

	public Transform target;
	public float speed;

	private Vector3 start,end;

	// Use this for initialization
	void Start () {
		if(target!=null){
			target.parent=null;
			start=transform.position;
			end=target.position;
		}
	}

	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
		if(target!=null){
			float fixedSpeed=speed*Time.deltaTime;
			transform.position=Vector3.MoveTowards(transform.position,target.position,fixedSpeed);
		}
		if(transform.position==target.position){
			target.position=(target.position==start)? end: start; // el operador ternario ? hara que compruebe la condicion , si es true el target pasara a la posicion end, y si es false a la posicion start

		}
	}
}
