using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punk2Controller : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D                     rig;
    private Animator                        PA;

    [Header("Movimentos")]
    private GameObject                      player;
    private Vector2                         movimentos;
    [SerializeField]private float           speed;
    [SerializeField]private float           distanceRange;

    [Header("Ataque do Inimigo")]
    [SerializeField]private int             quantidadeAtaques;
    private int                             ataqueAtual;
    
    [Header("Cronometro de Ataque")]
    private bool                            isAttack;
    [SerializeField]private float           tempoMaxAttack;
    private float                           tempoAtualAttack;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        PA = GetComponent<Animator>();

        player = FindObjectOfType<Player>().gameObject;
    }

    
    void Update()
    {
        
        if(GetComponent<VidaInimigo_2>().inimigoVivo){

            Mover();
            CronometroAtaque();
            EspelharInimigo();
            
        }
        else{

            DieAnimation();
        }
        
    }

    void Mover(){

        if(Vector2.Distance(transform.position, player.transform.position) > distanceRange){

            movimentos = (player.transform.position - transform.position).normalized;
            rig.velocity = movimentos * speed;

            PA.SetTrigger("isWalk");
        }
        else{

            rig.velocity = Vector2.zero;
            SortearAtaque();
        }
    }

    void EspelharInimigo(){

        if(player.transform.position.x > transform.position.x){

            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(player.transform.position.x < transform.position.x){

            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    

    }

    void IniciarAtaque(){

        if(ataqueAtual == 0){
            PA.SetTrigger("Light-Punch");
            SoundManager.Instance.impactoSoco.Play();
        }
        else if(ataqueAtual == 1){
            PA.SetTrigger("Heavy-Punch");
            SoundManager.Instance.impactoChute.Play();
        }

        isAttack = false;
    }

    void SortearAtaque(){

        ataqueAtual = Random.Range(0, quantidadeAtaques);
        
        if(isAttack){

            IniciarAtaque();
        }
    }

    void CronometroAtaque(){

        tempoAtualAttack -= Time.deltaTime;
        if(tempoAtualAttack <= 0){

            isAttack = true;
            tempoAtualAttack = tempoMaxAttack;
        }
    }

    public void HurtAnimation(){

        PA.SetTrigger("Hurt");
    }

    public void DieAnimation(){

        PA.Play("Punk2_Die");
        rig.velocity = Vector2.zero;
    }
}
