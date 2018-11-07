using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerte : MonoBehaviour {
// cuando el jugador cae en la zona de muerte colisiona con el collider2d, entonces queremos que el jugador vuelva al punto de partida 
    public string m_Tag = "Player";



    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.CompareTag(m_Tag))
        {

            other.gameObject.SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);

        }

    }
}
