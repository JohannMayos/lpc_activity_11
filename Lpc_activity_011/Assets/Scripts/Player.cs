using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{


        public float Speed;
        public float JumpForce;
        public bool isJumping;
        public bool doubleJump;

        private Rigidbody2D rig;
        private Animator anim;
        bool isBlowing;


        // Start is called before the first frame update
        void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Jump();
        }

        void Move()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            
            if(Input.GetAxis("Horizontal") > 0f){

                anim.SetBool("New Bool" , true);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                
            }

            if(Input.GetAxis("Horizontal") < 0f){
                anim.SetBool("New Bool" , true);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }

            if(Input.GetAxis("Horizontal") == 0f){
                anim.SetBool("New Bool" , false);
            }

            
        }

        void Jump()
        {
            if(Input.GetButtonDown("Jump") && !isBlowing)
            {
                if(!isJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = true;
                    anim.SetBool("New Bool 0" , true);
                }
                else
                {
                    if(doubleJump)
                    {
                        rig.AddForce(new Vector2(0f, JumpForce * 1f), ForceMode2D.Impulse);
                        doubleJump = false;
                    }
                }
                
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 8)
            {
                isJumping = false;
                anim.SetBool("New Bool 0" , false);
            }

            if(collision.gameObject.tag == "Spike")
            {
                Controller.Instance.ShowGameOver();
                Destroy(gameObject);
            }

             if(collision.gameObject.tag == "Saw")
            {
                Controller.Instance.ShowGameOver();
                Destroy(gameObject);
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 8)
            {
                isJumping = true;
            }
        }

        void OnTriggerStay2D(Collider2D collider){

            if(collider.gameObject.layer == 11){
                isBlowing = true;
                
            }
        }

        void OnTriggerExit2D(Collider2D collider){

            if(collider.gameObject.layer == 11){
                isBlowing = false;
                
            }
        }

}
    


