using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBulletController : MonoBehaviour
{
    public float speed = 2;
    
    public float lifeTime = 2;
    public float time = 0;
    public bool right = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(right){
            transform.Translate(Vector2.right*speed*Time.deltaTime);    //MOVIMIENTO HACIA LA DERECHA
        }else{
            transform.Translate(Vector2.left*speed*Time.deltaTime);     //MOVIMIENTO HACIA LA IZQUIERDA
        }
        
        if(time>=lifeTime){         //TIEMPO DE VIDA DE LA BALA
            
            animator.Play("plantBulletDestroyAnim");    //DESTRUCCION DE LA BALA CON LA ANIMACIÓN
            Destroy(gameObject,0.1f);
        }else{
            time = time + Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision) {     //COLISIONA CON EL JUGADOR SE DESTRUYE LA BALA
        
        animator.Play("plantBulletDestroyAnim");
        Destroy(gameObject,0.1f);
    }
}
