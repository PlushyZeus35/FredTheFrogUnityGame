using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlantController : MonoBehaviour
{
   public Animator animator;
    public SpriteRenderer spriterender;
    
    private float waitTime;
    //TIEMPO DE ESPERA ENTRE BALAS
    public float startWaitTime = 2;
    //REFERENCIA AL PREFAB DE LA BALA QUE SE VA A CREAR
    public GameObject bulletPrefab;
   
    //REFERENCIA AL PUNTO DONDE SE VAN A CREAR LAS BALAS
    public Transform launchSpawnPoint;
    public bool withPlayerDetection=true;
    public bool right = false;
    public AudioSource audioSource;
    
    

    // Start is called before the first frame update
    void Start()
    {
        waitTime=startWaitTime;
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
        if(right){
            spriterender.flipX = true;
        }
        
    }

    void Update()
    {
        
        if(withPlayerDetection){    //SI TENEMOS ACTIVADA LA OPCION DE PLAYER DETECTION
            if(right){
                if(waitTime<=0 && RightPlayerDetection.playerDetected){            //ATAQUE!!
                waitTime=Random.Range(0.5f,2.0f); //RESETEA EL TIEMPO
                animator.SetTrigger("Shoot");   //INVOCA LA ANIMACIÓN DE ATAQUE DE LA PLANTA
            
                Invoke("LaunchBullet", 0.5f);   //INVOCA A UNA FUNCIÓN DE INSTANCIACIÓN DE LA BALA
                }else{
                    waitTime -= Time.deltaTime;
                }
            }else{      
                if(waitTime<=0 && LeftPlayerDetection.playerDetected){            //ATAQUE!!
                waitTime=Random.Range(0.5f,2.0f); //RESETEA EL TIEMPO
                animator.SetTrigger("Shoot");   //INVOCA LA ANIMACIÓN DE ATAQUE DE LA PLANTA
            
                Invoke("LaunchBullet", 0.5f);   //INVOCA A UNA FUNCIÓN DE INSTANCIACIÓN DE LA BALA
                }else{
                    waitTime -= Time.deltaTime;
                }
            }
            
        }else{                  //CON OPCION DE PLAYER DETECION DESACTIVADA EL ATAQUE ES CONTINUO
            if(waitTime<=0){            //ATAQUE!!
                waitTime=Random.Range(0.5f,2.0f); //RESETEA EL TIEMPO
                animator.SetTrigger("Shoot");   //INVOCA LA ANIMACIÓN DE ATAQUE DE LA PLANTA
            
                Invoke("LaunchBullet", 0.5f);   //INVOCA A UNA FUNCIÓN DE INSTANCIACIÓN DE LA BALA
            }else{
                waitTime -= Time.deltaTime;
            
            }
        }
        
    }
    //LANZA LA BALA
    public void LaunchBullet(){
        GameObject newBullet;
        //INSTANCIAMOS UNA NUEVA BALA
        newBullet = Instantiate(bulletPrefab,launchSpawnPoint.position,launchSpawnPoint.rotation);
        audioSource.Play(); //REPRODUCIMOS AUDIO
        if(right){          //SI LA PLANTA ESTÁ ORIENTA HACIA LA IZQUIERDA CAMBIAMOS LA DIRECCIÓN DE LA BALA
            newBullet.gameObject.GetComponent<PlantBulletController>().right=true;
        }
        
    }
}
