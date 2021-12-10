using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public AudioSource audioSource;
    //EVENTO DE COLISION CON EL COLLIDER
    private void OnTriggerEnter2D(Collider2D colision) {
        //SI CHOCA CON EL JUGADOR
        if(colision.CompareTag("Player")){
            //QUITAMOS EL SPRITERENDERER DE LA FRUTA
            GetComponent<SpriteRenderer>().enabled = false;
            //ACTIVAMOS EL OBJETO DE ANIMACIÓN RECOLECTADO
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //DESTRUIMOS EL OBJETO FRUTA PASADO UN DELAY PARA QUE SE VEA LA ANIMACION
            Destroy(gameObject, 0.5f);
            //SONIDO DE COLLECTED
            audioSource.Play();
        }
    }
}
