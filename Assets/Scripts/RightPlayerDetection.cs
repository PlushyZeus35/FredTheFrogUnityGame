using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerDetection : MonoBehaviour
{
    //PARAMETRO BOOL PARA DETERMINAR SI EL JUGADOR HA SIDO DETECTADO
    static public bool playerDetected;
    //DISTANCIA DEL RAYO
    public float distance = 2.5f;
 
    void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();  //VARIABLE HIT DEL RAYO
        
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.right)*distance,Color.green); //DIBUJAMOS EL RAYO
        hit = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.right), distance);  //CREAMOS EL RAYO HACIA LA DERECHA CON LA DISTANCIA ELEGIDA
        
        if(hit){
            
             if(hit.collider.gameObject.tag == "Player"){   //SI EL RAYO ALCANZA EL JUGADOR
                 playerDetected = true;                     //ACTIVAMOS EL PARAMETRO
             }else{
                 playerDetected = false;                    //SINO LO DESACTIVAMOS
             }
             
         }else{
             playerDetected = false;                        //SINO LO DESACTIVAMOS
         }
    }
}
