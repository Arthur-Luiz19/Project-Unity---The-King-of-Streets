using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo_2 : MonoBehaviour
{
    
    [Header("Inimigo")]
    public  bool                    inimigoVivo;
    [SerializeField]private int     vidaMaxima;
    private int                     vidaAtual;
    [SerializeField]private float   tempoSumir;
    [SerializeField]private string  nomeInimigo;

    void Start()
    {
        inimigoVivo = true;
        vidaAtual = vidaMaxima;
    }

    public void InimigoLevarDano_2(int Dano){

        if(inimigoVivo){

            vidaAtual -= Dano;
            GetComponent<Punk2Controller>().HurtAnimation();
            UIManager.Instance.AtualizarBarraVidaInimigo(vidaMaxima, vidaAtual, nomeInimigo);

            if(vidaAtual <= 0){

                inimigoVivo = false;
                GetComponent<Punk2Controller>().DieAnimation();
                SoundManager.Instance.inimigoLevandoDano.Play();
                UIManager.Instance.DesativarPainelInimigo();
                Destroy(gameObject, tempoSumir);
            }
        }
    }

    
}
