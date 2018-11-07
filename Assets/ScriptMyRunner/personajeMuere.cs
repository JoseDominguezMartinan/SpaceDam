using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeMuere : MonoBehaviour {
    // script para indicar al objeto que tiene que volver al punto de partida

    public Transform puntoReinicio;
    public AudioClip dieClip; // variable publica para poder asignar un clip de audio desde unity que sonara cuando el personaje muera

    private AudioSource audioPlayer;



    // Use this for initialization

    void Start()
    {

        if (puntoReinicio != null)

            gameObject.transform.position = puntoReinicio.position;
            audioPlayer=GetComponent<AudioSource>();
    }





    public void OnDeath()
    {
      // asignamos a nuestro componente de audio el clip correspondiente y lo reproducimos
      audioPlayer.clip=dieClip;
      audioPlayer.Play();
        gameObject.transform.position = puntoReinicio.position;

        GameObject root = GameObject.FindGameObjectWithTag("Root");

        if (root != null)

            gameObject.transform.parent = root.transform;

        else

            gameObject.transform.parent = null;

    }
}
