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

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //playerRb = GetComponent<Rigidbody>();
        //sound = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void MovementPlayer() // Metodo para mover el personaje
    {
        x = Input.GetAxisRaw("Horizontal"); //Obtiene el input para moverse horizontalmente

        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0); //Recibe el input para mover el personaje de manera horizontal
        anim.SetFloat("VelX", x);
       
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
}
