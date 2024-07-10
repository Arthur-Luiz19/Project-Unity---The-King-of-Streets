using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
   
   
   [Header("UI Tela")]
   [SerializeField]private Animator     TA;

   [Header("UI Tela GameOver")]
   [SerializeField]public  GameObject   telaGameOver;

   [Header("UI do Inimgo")]
   [SerializeField]private GameObject   painelInimigo;
   [SerializeField]private Slider       barraVidaInimigo;
   [SerializeField]private TMP_Text     textoNomeDoInimigo;

   [Header("UI do Player")]
   [SerializeField]private Slider       barraVidaPlayer;


   public static UIManager              Instance;
    
    void Awake(){

        Instance = this;
    }
    
    void Start()
    {
        DesativarPainelInimigo();
        ClarearTelaTransicao();
        telaGameOver.SetActive(false);
    }

    public void AtivarPainelInimigo(){

        painelInimigo.SetActive(true);
    }

    public void DesativarPainelInimigo(){

        painelInimigo.SetActive(false);
    }

    public void AtualizarBarraVidaInimigo(int valorMaximo, int valorAtual, string nomeDoInimigo){

        barraVidaInimigo.maxValue = valorMaximo;
        barraVidaInimigo.value = valorAtual;

        textoNomeDoInimigo.text = nomeDoInimigo;

        AtivarPainelInimigo();
    }

    public void AtualizarBarraVidaPlayer(int valorMaximo, int valorAtual){

        barraVidaPlayer.maxValue = valorMaximo;
        barraVidaPlayer.value = valorAtual;

    }

    public void TelaGameOver(){

        telaGameOver.SetActive(true);
    }

    public void EscurerTelaTransicao(){

        TA.Play("Imagem-De-Transicao-escurecendo");
    }

    public void ClarearTelaTransicao(){

        TA.Play("Imagem-De-Transicao-clareando");
    }

    

    
}
