using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveTo : MonoBehaviour {

	public Transform goal;
	public Transform goal2;
	private int posicion;
	 private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking=false;
		posicion=1;
		GotoNextPoint();

	}

	// Update is called once per frame
	void Update () {

		 if(agent.remainingDistance<0.2f){
			 if(posicion==0){
			 posicion=1;
			 GotoNextPoint();
		 }
			 if(posicion==1){
			 posicion=0;
			 GotoNextPoint();
		 }

		 }
	}
	void GotoNextPoint(){
		if(posicion==0){
		agent.destination=goal2.position;

	}
		if(posicion==1){
			agent.destination=goal.position;

		}
	}

}
