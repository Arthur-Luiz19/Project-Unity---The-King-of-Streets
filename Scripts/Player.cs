using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator    PA;
    public  Transform   groundCheck;
    public  Vector2     Direction;
    private bool        isWalk = false;
    private bool        isJump = false;
    public  float       speed = 5f;
    public  float       jumpForce = 10f;
    private int         numPulos = 0;
    private int         maxPulos = 1;
    public  bool        facingRight;
    public  bool        isGrounded;
    private Vector2     initialPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        PA = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Animations();

        
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        PA.SetBool("isGrounded", isGrounded);
        Debug.Log("isGrounded");

        if(Input.GetKeyDown(KeyCode.K) && isGrounded){
            isJump = true;
        } 

       
    }

    private void FixedUpdate(){

        
        rig.MovePosition(rig.position + Direction.normalized * speed * Time.fixedDeltaTime);
        
        if(Direction.x != 0 || Direction.y != 0){

            isWalk = true;
        }
        else{

            isWalk = false;
        }

        

        if(isJump){

            Jump();
        }
        
            
       
    }

    void PlayerMove(){
        
        
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
        if(Direction.x < 0 && facingRight || Direction.x > 0 && !facingRight){

            Flip();
         }
 
    }

    void Animations(){

        PA.SetBool("isWalk", isWalk);
        PA.SetBool("isJump", isJump);
    }

    void Flip(){

        facingRight = !facingRight;
        transform.Rotate(0f, 180, 0f);
    }

    void Jump(){

        if(isGrounded){
            numPulos = 0;
        }
        
        if(isGrounded || numPulos < maxPulos){

            Debug.Log("pulou");
            initialPosition = transform.position;
            StartCoroutine(JumpCoroutine());
            PA.SetTrigger("jump");
            isGrounded = false;
            numPulos++;
        }
            isJump = false;
            
    }

    IEnumerator JumpCoroutine(){

        float duracaoPulo = 0.5f;
        float jumpSpeed = jumpForce / duracaoPulo;
        float timer = 0f;

        while(timer < duracaoPulo / 2){

            transform.position += new Vector3(Direction.x * jumpForce * Time.deltaTime, speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        float groundY = initialPosition.y;
        Vector3 startPosition = transform.position;
        
        while(timer < duracaoPulo / 2){

            float t = timer / (duracaoPulo / 2);
            float smoothStep = Mathf.SmoothStep(0, 1, t); // Suavização da descida
            transform.position = Vector3.Lerp(startPosition, new Vector3(startPosition.x, groundY, startPosition.z), smoothStep);
            timer += Time.deltaTime;
            yield return null;
        }
            
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);

    }

  
    
}
