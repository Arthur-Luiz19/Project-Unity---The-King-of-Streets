using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TelaMenu : MonoBehaviour
{
    
    [Header("Tela Menu")]
    [SerializeField]private TextMeshProUGUI press;
    [SerializeField]private TextMeshProUGUI iniciar;
    [SerializeField]private TextMeshProUGUI sair;
    [SerializeField]private AudioSource     startGame;
    private bool                            isPressActive = true;

    void Start()
    {
        iniciar.enabled = false;
        sair.enabled = false;
    }

    
    void Update()
    {
        
        Pressione();
        Sair();
        
        
    }

    public void Pressione(){

        if(Input.GetKeyDown(KeyCode.Return)){

            if(isPressActive){

                startGame.Play();
                StartCoroutine(PressioneBlink());
            }
            else{

                Iniciar();
            }
        }
    }

    IEnumerator PressioneBlink(){

        for(float i = 0; i < 1f; i += 0.2f){

            press.enabled = false;
            yield return new WaitForSeconds(0.1f);
            press.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

            press.enabled = false;
            iniciar.enabled = true;
            sair.enabled = true;
            isPressActive = false;
    }

    public void Iniciar(){

        startGame.Play();
        StartCoroutine(IniciarCoroutine());
    }

    IEnumerator IniciarCoroutine(){

        for(float i = 0; i < 1; i += 0.2f){

            iniciar.enabled = false;
            yield return new WaitForSeconds(0.1f);
            iniciar.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        
        SceneManager.LoadScene("Introdução");
    }

    public void Sair(){

        if(Input.GetKeyDown(KeyCode.Escape)){

            startGame.Play();
            StartCoroutine(SairCoroutine()); 
        }
    }

    IEnumerator SairCoroutine(){


     for(float i = 0; i < 1; i += 0.2f){

         sair.enabled = false;
         yield return new WaitForSeconds(0.1f);
         sair.enabled = true;
         yield return new WaitForSeconds(0.1f);
     }

         Application.Quit();
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
    }
}
