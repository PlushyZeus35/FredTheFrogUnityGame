using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    //VELOCIDAD DEL PERSONAJE
    public float speed = 1.5f;
    //FUERZA DEL SALTO
    public float jump = 3.5f;
    //REFERENCIAS A COMPONENTES
    public Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        //INICIALIZAMOS LAS REFERENCIAS A LOS COMPONENTES
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RECOGEMOS MOVIMIENTO HORIZONTAL
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //CONTROLAMOS LA ANIMACION DE CORRER
        if(rb.velocity.x<0){
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }else if(rb.velocity.x>0){
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }else{
            anim.SetBool("isRunning", false);
        }

        //RECOGEMOS MOVIMIENTO VERTICAL (SALTO) COMPROBANDO VARIABLE isGround
        if(Input.GetKey("space") && GroundTestController.isGround){
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        //CONTROLAMOS LA ANIMACIÓN DE SALTO
        if(GroundTestController.isGround == false){
            anim.SetBool("isJumping", true);
        }else{
            anim.SetBool("isJumping",false);
        }
    }
}
