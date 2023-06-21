using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 10.0f;
    public float x, y;
    public Animator anim;
    [SerializeField] Rigidbody playerRb;
    //[SerializeField] private Collider colliderDePie;
    [SerializeField] public Transform giroCharacter;
    [SerializeField] private Quaternion giroAtras;
    [SerializeField] private Quaternion giroFrente;
    //[SerializeField] private AudioSource sound;
    //[SerializeField] private AudioClip auch;

    /*[Header("Salto")]
    [SerializeField] private float jumpForce = 15.0f;
    [SerializeField] private GameObject checkGround;
    [SerializeField] private bool enElSuelo;
    [SerializeField] private AudioClip jumpSound;*/

    /*[Header("Agachado")]
    [SerializeField] private Collider colliderAgachado;
    [SerializeField] public bool agachado = false;
    [SerializeField] public bool estaAgachado = false;*/
       

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //playerRb = GetComponent<Rigidbody>();
        //sound = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        //MoverPlayer();

        //Correr();
        //Jump();
        //Ataque();
       
    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void MoverPlayer() // Metodo para mover el personaje
    {
        x = Input.GetAxisRaw("Horizontal"); //Obtiene el input para moverse horizontalmente

        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0); //Recibe el input para mover el personaje de manera horizontal
        anim.SetFloat("VelX", x);
       

        /*Vector3 direction = GetComponent<Rigidbody>().velocity;

        direction.y = playerRb.velocity.y;
        playerRb.velocity = direction;*/

        //Giro del personaje izquierda
        if (x < 0)
        {
            giroCharacter.transform.rotation = giroAtras;
        }
        //Giro del personaje derecha
        else if (x > 0)
        {
            giroCharacter.transform.rotation = giroFrente;
        }

    }

    /*private void OnTriggerEnter(Collider other) // Metodo que determina despues de tomar el power up para cambiar el estado a verdadero
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            enElSuelo = true;
            //anim.SetBool("OnAir", false);
        }*/

        /*if (other.gameObject.CompareTag("PwrupJump"))
        {
            Debug.Log("Puedes Saltar");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PwrupCrouch"))
        {
            Debug.Log("Puedes Agacharte");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PwrupAttack"))
        {
            Debug.Log("Puedes Atacar");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            sound.PlayOneShot(auch);
        }
    }*/

    /*private void OnTriggerExit(Collider other) //Metodo para corroborar que el personaje esta tocando el suelo
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            enElSuelo = false;
            //anim.SetBool("OnAir", true);
        }
    }*/
    /*public void Jump() // Metodo de salto
    {
        if (Input.GetKey(KeyCode.Space) && enElSuelo)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enElSuelo = false;
            anim.SetTrigger("Jump");
            sound.PlayOneShot(jumpSound);
        }
    }*/

    /*public void Agachado() // Metodo para activar y desactivar el area de un collider
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //agachado = true;
            //estaAgachado = true;
            //colliderAgachado.enabled = true;
            anim.SetBool("Crouch", true);
            //colliderDePie.enabled = false;
            Debug.Log("Agachado");
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //estaAgachado = false;
            //agachado = false;
            //colliderAgachado.enabled = false;
            //colliderDePie.enabled = true;
            anim.SetBool("Crouch", false);
            Debug.Log("De Pie");
        }
    }*/

    /*public void Ataque() // Metodo para atacar
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKey(KeyCode.JoystickButton3))
        {
            anim.SetTrigger("Attack");
        }
    }*/
}
