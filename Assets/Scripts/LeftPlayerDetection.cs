using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool playerDetected;
    public float distance = 2.5f;
         
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();
        
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.left)*distance,Color.red);
        hit = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.left), distance);
        
        if(hit){
            
             if(hit.collider.gameObject.tag == "Player"){
                 playerDetected = true;
             }else{
                 playerDetected = false;
             }
             
         }else{
             playerDetected = false;
         }
    }
}
