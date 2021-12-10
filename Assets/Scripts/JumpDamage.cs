using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JumpDamage : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    //FUERZA DE SALTO DEL JUGADOR AL GOLPEAR EL ENEMIGO
    public float jumpForce = 2.5f;
    //NUMERO DE VIDAS DEL ENEMIGO
    public int lifes = 2;
    //PARAMETRO PARA DETERMINAR SU MUERTE
    static public bool death=false;
    public AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D colision) {
        
        if(colision.transform.CompareTag("Player")){        //SI ENTRA EN COLISIÓN CON EL JUGADOR
            audioSource.Play();                             //ACTIVAMOS EL SONIDO
            colision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);    //EMPUJAMOS EL JUGADOR HACIA ARRIBA
            Hitted();           //EJECUTAMOS FUNCION Hitted
            CheckLife();        //COMPROBAMOS VIDAS DEL ENEMIGO
            
        }
    }

    public void Hitted(){   //RESTAMOS UNA VIDA Y REPRODUCIMOS ANIMACIÓN DE DAÑO
        lifes--;
        animator.Play("Hit");
    }

    public void CheckLife(){    //SI NO LE QUEDAN VIDAS SE DESTRUYE
        if(lifes==0){
            Destroy(gameObject,0.2f);
        }
    }
}
