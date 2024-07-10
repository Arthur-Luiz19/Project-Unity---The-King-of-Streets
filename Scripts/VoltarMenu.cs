using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VoltarMenu : MonoBehaviour
{
    
    [Header("Voltar Menu")]
    [SerializeField]private TextMeshProUGUI sair;
    [SerializeField]private TextMeshProUGUI fechar;
    [SerializeField]private GameObject      missaoCumprida;

    void Start()
    {
        AtivarTelaParabens();
    }

    // Update is called once per frame
    void Update()
    {
        MenuVoltar();
        SairJogo();
    }

    public void MenuVoltar(){

        if(Input.GetKeyDown(KeyCode.Return)){

            StartCoroutine(MenuCoroutine());
        }
    }

    public void SairJogo(){

        if(Input.GetKeyDown(KeyCode.Escape)){

            StartCoroutine(SairCoroutine());
        }
    }

    IEnumerator MenuCoroutine(){

        for(float i = 0; i < 1; i += 0.2f){

            yield return new WaitForSeconds(0.1f);
            sair.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sair.enabled = true;
        }

        SceneManager.LoadScene("Menu");
    }

    IEnumerator SairCoroutine(){

        for(float i = 0; i < 1; i += 0.2f){

            yield return new WaitForSeconds(0.1f);
            fechar.enabled = false;
            yield return new WaitForSeconds(0.1f);
            fechar.enabled = true;
        }
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
    }

    void AtivarTelaParabens(){

        StartCoroutine(ParabensCoroutine());
        

    }

    IEnumerator ParabensCoroutine(){

        missaoCumprida.SetActive(true);
        yield return new WaitForSeconds(5f);
        missaoCumprida.SetActive(false);
    }
}
