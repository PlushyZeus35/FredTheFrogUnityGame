using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    //REFERENCIA AL TEXTO DE LA INTERFAZ
    public Text texto;
    //NOMBRE DEL SIGUIENTE NIVEL A PASAR
    public string levelName;
    //PARAMETRO PARA INDICAR SI ESTAMOS ENCIMA DE LA PUERTA
    private bool inDoor = false;

    //EVENTO DE COLISION CON LA PUERTA 
    private void OnTriggerEnter2D(Collider2D colision) {
        if(colision.gameObject.CompareTag("Player")){       //LA PUERTA ENTRA EN COLISIÓN CON EL JUGADOR
            texto.gameObject.SetActive(true);               //ACTIVAMOS EL TEXTO DE LA INTERFAZ
            inDoor = true;                                  //ACTIVAMOS EL PARAMETRO inDoor
        }
    }

    private void OnTriggerExit2D(Collider2D colision) {     //SALIMOS DE LA COLISIÓN CON LA PUERTA
        texto.gameObject.SetActive(false);                  //DESACTIVAMOS EL TEXTO
        inDoor = false;                                     //DESACTIVAMOS EL PARAMETRO inDoor
    }

    void Update()
    {
        if(inDoor && Input.GetKey("e")){                    //SI PULSAMOS LA TECLA E Y ESTAMOS ENCIMA DE UNA PUERTA
            SceneManager.LoadScene(levelName);              //PASAMOS AL SIGUIENTE NIVEL
        }
    }

}
