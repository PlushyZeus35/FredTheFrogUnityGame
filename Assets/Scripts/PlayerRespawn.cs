using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    //DETERMINAMOS LOS VALORES DE POSICION DE INICIO
    public float checkPointPositionX=-1.0f;
    public float checkPointPositionY=0.0f;
    public Animator animator;
    //REFERENCIAS A LOS OBJETOS CORAZONES QUE REPRESENTAN LAS VIDAS
    public GameObject[] lifes;
    //VIDA ACTUAL
    private int life;
    public AudioSource audioSource;
    void Start()
    {
        //INICIAMOS EL PERSONAJE EN LA POSICIÓN INICIAL DEL MAPA
        transform.position=new Vector2(checkPointPositionX,checkPointPositionY);
        animator = GetComponent<Animator>();
        //ESTABLECEMOS NUMERO DE VIDAS
        life = lifes.Length;
    }

    //CON CADA DAÑO COMPROBAMOS CUANTAS VIDAS NOS QUEDAN
    void CheckLifes()
    {

        if(life < 1){   //NO NOS QUEDAN VIDAS TENEMOS QUE MORIR
            lifes[0].gameObject.GetComponent<Animator>().SetBool("damage",true);    //ACTIVAMOS ANIMACIÓN DEL CORAZON DAÑADO EN LA INTERFAZ
            animator.Play("hitFrogAnim");                                           //ACTIVAMOS ANIMACIÓN DE HIT DEL JUGADOR RANA
            audioSource.Play();                                                     //ACTIVAMOS SONIDO DE DAÑO
            transform.position=new Vector2(checkPointPositionX,checkPointPositionY);//COMO HEMOS MUERTO REAPARECEMOS EN LAS POSICIONES MARCADAS POR LAS VARIABLES
            life = lifes.Length;                                                    //REINICIAMOS LAS VIDAS
            lifes[0].gameObject.GetComponent<Animator>().SetBool("damage",false);   //REINICIAMOS LAS ANIMACIONES DE LOS CORAZONES DE LA INTERFAZ
            lifes[1].gameObject.GetComponent<Animator>().SetBool("damage",false);
            lifes[2].gameObject.GetComponent<Animator>().SetBool("damage",false);
        }else if(life<2){   //NOS QUEDA UNA VIDA
            lifes[1].gameObject.GetComponent<Animator>().SetBool("damage",true);    //ACTIVAMOS ANIMACIÓN DEL SEGUNDO CORAZÓN EN LA INTERFAZ
            animator.Play("hitFrogAnim");                                           //ACTIVAMOS ANIMACIÓN DE HIT DEL JUGADOR RANA
            audioSource.Play();                                                     //ACTIVAMOS EL SONIDO DE DAÑO
        }else if(life<3){   //NOS QUEDAN DOS VIDAS
            lifes[2].gameObject.GetComponent<Animator>().SetBool("damage",true);    //ACTIVAMOS ANIMACIÓN DEL TERCER CORAZÓN EN LA INTERFAZ
            animator.Play("hitFrogAnim");                                           //ACTIVAMOS LA ANIMACIÓN DE HIT DEL JUGADOR RANA
            audioSource.Play();                                                     //ACTIVAMOS SONIDO DE DAÑO
        }
    }

    //FUNCIÓN PARA SER LLAMADA AL DAÑARSE EL JUGADOR
    public void PlayerDamaged(){
        life = life - 1;            //RESTAMOS UNA VIDA
        CheckLifes();               //COMPROBAMOS LAS VIDAS QUE NOS QUEDAN
    }

    //FUNCIÓN PARA ACTUALIZAR LAS COORDENADAS DE REAPARICIÓN SI ALCANZAMOS UN CHECKPOINT
    public void ReachedCheckPoint(float x, float y){
        
        checkPointPositionX = x;
        checkPointPositionY = y;
    }
}
