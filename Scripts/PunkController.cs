using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunkController : MonoBehaviour
{
    
    [Header("Componentes")]
    private SpriteRenderer  sprite;
    private Rigidbody2D     rig;
    private Animator        PA;
    private Player          _player;

    [Header("Movimentos")]
    private Vector2         movements;
    public  Transform       enemie;
    public  float           speed = 2f;
    private bool            facingRight;
    public  float           distanceRange;

    [Header("Vida")]
    private int             life = 5;
    public  Transform       Hit;
    public  Transform       Die;
    private GameObject      player;

    [Header("Ataque")] 
    private float           attackRange = 1f;
    private bool            isAttack;
    public  float           maxAttackTime;
    private float           currentAttackTime;
    private int             punchCount = 0;
    

    void Start()
    {
        sprite = enemie.GetComponent<SpriteRenderer>();
        PA = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<Player>().gameObject;
        
    }

    void Update()
    {
        if(GetComponent<VidaInimigo>().inimigoVivo){

            Mover();
            CronometroAtaque();
        }
        else{

            DieAnimation();
        }
        
        

            if(player.transform.position.x < enemie.position.x && !facingRight){

                Flip();
            }
            else if(player.transform.position.x > enemie.position.x && facingRight){

                Flip();
            }
    }

    void Flip(){

        facingRight = !facingRight;
        transform.Rotate(new Vector3(0f, 180f, 0f));
    }

    void CronometroAtaque(){

        currentAttackTime -= Time.deltaTime;
        if(currentAttackTime <= 0){

            isAttack = true;
            currentAttackTime = maxAttackTime;
        }
    }

    void Mover(){

        if(Vector2.Distance(transform.position, player.transform.position) > distanceRange){

            movements = (player.transform.position - transform.position).normalized;
            rig.velocity = movements * speed;

            PA.SetTrigger("Walk");
        }
        else{

            rig.velocity = Vector2.zero;
            if(isAttack){
                StartCoroutine(EnemieAttack());
            }
        }
    }

    public void HurtAnimation(){
      
        PA.SetTrigger("Hit");
    }

    public void DieAnimation(){
      
        PA.Play("Punk_Die");
        rig.velocity = Vector2.zero;
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

    IEnumerator EnemieAttack(){

        punchCount++;
        
            if (punchCount == 0)
            {
                Attack1();
            }
            else if (punchCount == 1)
            {
                Attack2();
            }
            else if (punchCount == 2)
            {
                Attack3();
            }                                   
            else if (punchCount == 3)
            {
                Attack4();
                punchCount = -1; // Reiniciar a contagem
            }

            yield return new WaitForSeconds(0.5f);

        isAttack = false;
    }

    public void EndAttack(){

        isAttack = false;
    }
        
}
