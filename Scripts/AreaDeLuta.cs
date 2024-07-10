using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeLuta : MonoBehaviour
{
    [Header("Verificação")]
    private bool                            verificarPlayer;
    private bool                            spawnInimigo;

    [Header("Cronômetro Spawn")]
    [SerializeField]private float           tempoMaxSpawn;
    private float                           tempoAtualSpawn;

    [Header("Controle do Spawn")]
    [SerializeField]private Transform[]     pontosSpawn;
    [SerializeField]private GameObject[]    Inimigos;
    private int                             inimigosSpawnados;
    private int                             inimigosAtual;


    void Start()
    {
        verificarPlayer = true;
        spawnInimigo = false;
    }

    
    void Update()
    {
        if(spawnInimigo && inimigosSpawnados < Inimigos.Length){

            CronometroSpawn();
        }
    }

    void SpawnarInimigos(){

        Transform pontoAleatorio = pontosSpawn[Random.Range(0, pontosSpawn.Length)];
        GameObject novoInimigo = Inimigos[inimigosAtual];

        Instantiate(novoInimigo, pontoAleatorio.position, pontoAleatorio.rotation);
        inimigosAtual += 1;
        inimigosSpawnados += 1;
    }

    void OnTriggerEnter2D(Collider2D other){

        if(verificarPlayer){

            if(other.gameObject.GetComponent<Player>() != null){

                verificarPlayer = false;
                spawnInimigo = true;
            }
        }
    }

    void CronometroSpawn(){

        tempoAtualSpawn -= Time.deltaTime;
        if(tempoAtualSpawn <= 0){

            SpawnarInimigos();
            tempoAtualSpawn = tempoMaxSpawn;

        }
    }
}
