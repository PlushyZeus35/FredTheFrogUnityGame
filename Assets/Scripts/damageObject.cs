using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageObject : MonoBehaviour
{
  
    private void OnCollisionEnter2D(Collision2D colision) {
        if(colision.transform.CompareTag("Player")){
            
            colision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
