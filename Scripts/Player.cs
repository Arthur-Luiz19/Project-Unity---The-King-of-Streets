using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [Header("Componentes")]
    private Rigidbody2D     rig;
    private Animator        PA;
    private PunkController  _PunkController;
    private ObjectDestroy   _objectDestroy;

    [Header("Vida")]
    private int             maxHealth = 10;
    private int             Life = 3;
    private int             currentLife;

    [Header("Movimentos")]
    public  Vector2         Direction;
    private bool            isWalk = false;
    public  float           speed = 5f;
    public  bool            facingRight;

    [Header("Danos")]
    public  float           tempoMaxDano;
    private float           tempoAtualDano;
    private bool            LevouDano;

    [Header("Ataque")]
    private bool            isAttack;
    private float           timeCombo = 0.75f;
    private int             punchCount = 0;
    
    

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        PA = GetComponent<Animator>();
        currentLife = maxHealth;

        _PunkController = FindObjectOfType(typeof(PunkController)) as PunkController;
        _objectDestroy = FindObjectOfType(typeof(ObjectDestroy)) as ObjectDestroy;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<VidaController>().jogadorVivo){

            if(!LevouDano){

                PlayerMove();
                Animations();
            }
            else{

                HitCronometro();
            }
        }
        else{

            DeadAnimation();
        }

        if(Input.GetKeyDown(KeyCode.J) && isAttack == false){
            
            if(isWalk == false){

                StartCoroutine(PunchController());
                
                if(punchCount < 1){

                    isAttack = true;
                    
                    Attack1();
                    SoundManager.Instance.impactoSoco.Play();
                    punchCount++;
                }
                else if ( punchCount < 2){

                    
                    Attack2();
                    SoundManager.Instance.impactoSoco.Play();
                    punchCount++;
                }
                else if( punchCount < 3){

                    isAttack = true;
                    
                    Attack3();
                    SoundManager.Instance.impactoChute.Play();
                    punchCount++;
                }
                else if(punchCount <= 4){
                    
                    
                    Attack4();
                    SoundManager.Instance.golpeEspecial.Play();
                    punchCount = 0;
                }

                StopCoroutine(PunchController());
            }
        }
       
    }

    private void FixedUpdate(){

        
        if(!LevouDano){

            rig.MovePosition(rig.position + Direction.normalized * speed * Time.fixedDeltaTime);
        
            if(Direction.x != 0 || Direction.y != 0){

                isWalk = true;
            }
            else{

                isWalk = false;
            }

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
    }

    void Flip(){

        facingRight = !facingRight;
        transform.Rotate(0f, 180, 0f);
    }


    void Attack1(){
        PA.SetTrigger("Attack1");

    }

    void Attack2(){
        PA.SetTrigger("Attack2");

    }

    void Attack3(){
        PA.SetTrigger("Attack3");

    }

    void Attack4(){
        PA.SetTrigger("Attack4");

    }

    IEnumerator PunchController(){

        yield return new WaitForSeconds(timeCombo);
        punchCount = 0;
    }

    public void EndAttack(){

        isAttack = false;
    }

    public void HitAnimation(){

        PA.SetTrigger("Hit");
        LevouDano = true;

        rig.velocity = Vector2.zero;
    }

    void HitCronometro(){

        tempoAtualDano -= Time.deltaTime;

        if(tempoAtualDano <= 0){
            
            LevouDano = false;
            tempoAtualDano = tempoMaxDano;
        }
    }

    public void DeadAnimation(){

        PA.Play("Player_Die");
    }
}
