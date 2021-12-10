using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTestController : MonoBehaviour
{
    //VARIABLE BOOL PARA SABER SI ESTÁ TOCANDO EL SUELO
    static public bool isGround;

    //EVENTOS COLISION
    private void OnTriggerEnter2D(Collider2D colision) {
        //SI ENTRA EN COLISIÓN CON EL SUELO
        if(colision.CompareTag("Floor")){
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colision) {
        //SI DEJA DE ENTRAR EN COLISIÓN CON EL SUELO
        if(colision.CompareTag("Floor")){
            isGround = false;
        }
    }
}
