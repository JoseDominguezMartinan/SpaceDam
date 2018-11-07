using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2D : MonoBehaviour {
    public float m_DampTime = 10f;

    public Transform m_Target;

    public float m_XOffset = 0;

    public float m_YOffset = 0;

    private float margin = 0.1f;


	// Use this for initialization
	void Start () {
		if (m_Target==null){

			m_Target = GameObject.FindGameObjectWithTag("Player").transform; // posicionamos la camara en el objeto 

		}

	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Target)  // posicionamos la camara segun la posicion del objeto player
        {

            float targetX = m_Target.position.x + m_XOffset; 

            float targetY = m_Target.position.y + m_YOffset;



            if (Mathf.Abs(transform.position.x - targetX) > margin)

                targetX = Mathf.Lerp(transform.position.x, targetX, 1 / m_DampTime * Time.deltaTime);



            if (Mathf.Abs(transform.position.y - targetY) > margin)

                targetY = Mathf.Lerp(transform.position.y, targetY, 1 / m_DampTime * Time.deltaTime);



            transform.position = new Vector3(targetX, targetY, transform.position.z);

        }
	}
}
