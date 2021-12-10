using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public AudioSource audioSource;
    //PARAMETRO PARA REPRESENTAR SI EL CHECKPOINT YA HA SIDO ACTIVADO 
    private bool reached = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colision) {        
        if(colision.CompareTag("Player")){                          //ENTRAMOS EN COLISION CON EL JUGADOR
            if(!reached)                                            //SI ES LA PRIMERA VEZ QUE PASAMOS ACTIVAMOS EL SONIDO
                audioSource.Play();
            reached = true;
            colision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x,transform.position.y);    //LE PASAMOS LAS COORDENADAS AL JUGADOR
            animator.SetBool("reached",true);                       //ACTIVAMOS LA ANIMACIÓN DE LA BANDERA
        }
    }
}
