using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaController : MonoBehaviour
{
    
    [Header("Controle da Vida")]
    public  bool    jogadorVivo;
    public  int     vidaMaxima;
    private int     vidaAtual;
    public  float   tempoTela;

    void Start()
    {
        jogadorVivo = true;
        vidaAtual = vidaMaxima;

        UIManager.Instance.AtualizarBarraVidaPlayer(vidaMaxima, vidaAtual);
    }

    public void LevarDano(int Dano){

        if(jogadorVivo){

            vidaAtual -= Dano;
            GetComponent<Player>().HitAnimation();
            UIManager.Instance.AtualizarBarraVidaPlayer(vidaMaxima, vidaAtual);
            Debug.Log(vidaAtual);

            if(vidaAtual <= 0){

                jogadorVivo = false;
                GetComponent<Player>().DeadAnimation();
                StartCoroutine(AtivarGameOver());
            }
        }

    }

    public void AumentarVida(int lifeUp){

        if(vidaAtual + lifeUp <= vidaMaxima){

            vidaAtual += lifeUp;
            Debug.Log("Vida ganha " + vidaAtual);
        }
        else{

            vidaAtual = vidaMaxima;
        }

        UIManager.Instance.AtualizarBarraVidaPlayer(vidaMaxima, vidaAtual);
    }

    IEnumerator AtivarGameOver(){

        yield return new WaitForSeconds(tempoTela);
        UIManager.Instance.TelaGameOver();
       
    }

    
}
