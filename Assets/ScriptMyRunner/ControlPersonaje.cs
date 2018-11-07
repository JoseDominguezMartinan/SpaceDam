using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPersonaje : MonoBehaviour
{
    public float velocidadMaxima = 1f;
    public float velocidad = 0.5f;
    public LayerMask groundLayerMask;
    public enum GameState { Idle, Playing }; // enumerador para saber si el juego esta parado o se esta jugando
    public GameState gameState=GameState.Idle; // partimos del juego parado , para asi mostrar la pantalla de inicio
    public GameObject uiIdle;
    public GameObject uiScore;
    public float jumpForce=9.9f;
    public Text puntosTexto;
    public AudioClip jumpClip; // variable publica para poder asignar un clip de audio desde unity que sonara cuando el personaje salte
    public AudioClip monedas;
    public GameObject musica; // en este game object meteremos el objeto donde esta el componente con la musica de fondo para asi poder pararla o reproducirla en el momento que nosotros queramos

    private Rigidbody2D rigi;
    private Animator anim;
    private bool facingRight;
    private bool jump = false;
    private bool grounded = false;
    private Transform groundCheck;
    private int puntos = 0;
    private int salto=0; // recoge el numero de saltos que lleva el personaje, en determinados momentos se podra permitir el doble salto por lo que es necesario esto

    private AudioSource audioPlayer;


    void Start()
    {
        uiScore.SetActive(false);
        rigi = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        facingRight = false;
        Flip();
        audioPlayer=GetComponent<AudioSource>();



    }
    void Awake()
    {

        // Setting up references.

        groundCheck = transform.Find("groundCheck");

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(gameState==GameState.Idle &&(Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))){ // en caso de que se cumplan las condiciones empieza el juego
            gameState=GameState.Playing;
            uiIdle.SetActive(false);
            uiScore.SetActive(true);
            musica.GetComponent<AudioSource>().Play();


        }






    }

    void FixedUpdate()
    { // mejor el fixed update para trabajar con fisicas

        if (gameState == GameState.Playing)
        { // si el juego se pone en marcha
            movimientoJugador(); // llamamos al metodo que realiza los movimientos del personaje, de esta forma el codigo esta mas ordenado

        }
    }
    void OnCollisionStay2D(Collision2D col){
       if(col.gameObject.tag=="Ground"){
         grounded=true;
         salto=0;
       }
      if (col.gameObject.tag=="Movil"){
        transform.parent=col.transform;
        grounded=true;
      }
     }
     void OnCollisionExit2D(Collision2D col){
       if(col.gameObject.tag=="Ground" && salto>=2)
        grounded=false;
       if(col.gameObject.tag=="Movil"){
         transform.parent=null;
         grounded=true;
       }

     }


    void Flip()
    {

        Vector3 v;

        if (facingRight)

            v = Vector3.Slerp(Vector3.right, Vector3.left, 1.0f);

        else

            v = Vector3.Slerp(Vector3.left, Vector3.right, 1.0f);

        facingRight = !facingRight;



        transform.rotation = Quaternion.LookRotation(v);

    }




    void movimientoJugador(){
        float mover = Input.GetAxis("Horizontal");
        rigi.velocity = new Vector2(mover * velocidadMaxima, rigi.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(mover));
        if (Input.GetKeyDown(KeyCode.UpArrow)&& grounded){ // si pulsamos la tecla hacia arriba ponemos la variable booleana de salto a true, grounded es una condicion para que solo salte en caso de que se encuientre en el suelo, si no tendriamos un efecto flappy bird

            jump = true;
            salto++;
            if(salto>=2)
              grounded=false;
          }
        if (mover > 0 && !facingRight)

            Flip();

        if (mover < 0 && facingRight)

            Flip();

        if (jump) // esto es equivalente a if jump==true
        {

            // set el trigger del animator para saltar


            // añade una fuerza vertical al jugador para que salte

            rigi.AddForce(new Vector2(0, jumpForce));

            anim.SetTrigger("Jump");

            // asignamos a nuestro componente de audio el clip correspondiente y lo reproducimos
            audioPlayer.clip=jumpClip;
            audioPlayer.Play();

            // marca que no salte una vez que ya haya saltado
            jump = false;

        }
        }
    void OnTriggerEnter2D(Collider2D other) // cuando chocamos contra un enemigo
    {
        if (other.gameObject.tag == "Point")
        {
            IncrementarPuntos();
        }
    }

    public void IncrementarPuntos()
    {
      audioPlayer.clip=monedas;
      audioPlayer.Play();
        puntos++;
        puntosTexto.text = puntos.ToString();
    }
}
