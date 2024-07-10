using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager Instance;
    
    [Header("Efeitos Sonoros")]
    public AudioSource impactoChute;
    public AudioSource impactoSoco;
    public AudioSource golpeEspecial;
    public AudioSource inimigoLevandoDano;
    public AudioSource jogadorLevandoDano;
    public AudioSource pegarComida;

    [Header("Músicas")]
    [SerializeField]private AudioSource musicaGameOver;
    [SerializeField]private AudioSource musicaFase;
    
    
    void Awake(){

        Instance = this;
    }
    void Start()
    {
        MusicaFundo();
    }

    void Update()
    {
        
    }

    public void MusicaFundo(){

        musicaGameOver.Stop();
        musicaFase.Play();
    }

    public void MusicaGameOver(){

        musicaFase.Stop();
        musicaGameOver.Play();
    }
}
