using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    
    [Header("Vida do inimigo")]
    public  bool    inimigoVivo;
    public  int     vidaMaxima;
    private int     vidaAtual;
    public  float   tempoSumir;
    public  string  nomeInimgo;
    private void Start()
    {
        inimigoVivo = true;
        vidaAtual = vidaMaxima;
    }

    public void InimigoLevarDano(int Dano){

        if(inimigoVivo){

            
            vidaAtual -= Dano;
            GetComponent<PunkController>().HurtAnimation();
            UIManager.Instance.AtualizarBarraVidaInimigo(vidaMaxima, vidaAtual, nomeInimgo);
            Debug.Log(vidaAtual);

            if(vidaAtual <= 0){

                inimigoVivo = false;
                GetComponent<PunkController>().DieAnimation();
                SoundManager.Instance.inimigoLevandoDano.Play();
                UIManager.Instance.DesativarPainelInimigo();
                Destroy(gameObject, tempoSumir);  
                Debug.Log("Inimigo derrotado");
            }
        }
    }
    

    
}
