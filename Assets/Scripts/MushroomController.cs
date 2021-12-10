using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterender;
    //VELOCIDAD DE LA SETA
    public float speed = 0.5f;
    private float waitTime;
    //REFERENCIA A LOS WAYPOINTS
    public Transform[] moveSpots;
    //TIEMPO DE ESPERA INICIAL
    public float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        waitTime=startWaitTime;
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        //CORUTINA PARA DETERMINAR LAS ANIMACIONES DE LA SETA
        StartCoroutine(CheckEnemyMoving());
        //MOVIMIENTO HACÍA EL SIGUIENTE WAYPOINT DETERMINADO POR EL ARRAY moveSpots Y LA VELOCIDAD speed
        transform.position = Vector2.MoveTowards(transform.position,moveSpots[i].transform.position, speed * Time.deltaTime );

        //SI LA DISTANCIA AL WAYPOINT ES MENOR A 0.5 ESPERAMOS UN TIEMPO Y CAMBIAMOS EL WAYPOINT OBJETIVO
        if(Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.5f){
            if(waitTime<=0){
                if(moveSpots[i]!=moveSpots[moveSpots.Length-1]){
                    i++;
                }else{
                    i=0;
                }
                startWaitTime = Random.Range(2.0f,8.0f);    //TIEMPO DE ESPERA ALEATORIO ENTRE 2 Y 8
                waitTime = startWaitTime;
            }else{
                waitTime = waitTime - Time.deltaTime;
            }
        }
        
    }
    //COROUTINA DE EJECUCIÓN CADA 0.5 SEGUNDOS PARA CONTROLAS LAS ANIMACIONES DE LA SETA
    IEnumerator CheckEnemyMoving(){
        actualPosition = transform.position;
        yield return new WaitForSeconds(0.5f);

        if(transform.position.x > actualPosition.x){
            spriterender.flipX=true;
            animator.SetBool("idle",false);
        }else if(transform.position.x < actualPosition.x){
            spriterender.flipX=false;
            animator.SetBool("idle",false);
        }else if(transform.position.x == actualPosition.x){
            animator.SetBool("idle",true);
        }
    }

    
}
