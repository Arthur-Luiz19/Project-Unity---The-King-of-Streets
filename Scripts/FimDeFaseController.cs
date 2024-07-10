using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeFaseController : MonoBehaviour
{
    
    [Header("TransicaoTela")]
    [SerializeField]private float tempoParaEscurecer;
    [SerializeField]private float tempoDeTransicao;

    public string nomeProximaFase;
    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.GetComponent<Player>() != null){

            PunkController[] punkInimigos = FindObjectsOfType<PunkController>();
            Punk2Controller[] punk2Inimigos = FindObjectsOfType<Punk2Controller>();
            if(punkInimigos.Length == 0 && punk2Inimigos.Length == 0){

                StartCoroutine(EscurecerTela());
            }
        }
    }

    IEnumerator EscurecerTela(){

        yield return new WaitForSeconds(tempoParaEscurecer);
        UIManager.Instance.EscurerTelaTransicao();

        yield return new WaitForSeconds(tempoDeTransicao);
        SceneManager.LoadScene(nomeProximaFase);
    }
    
}
