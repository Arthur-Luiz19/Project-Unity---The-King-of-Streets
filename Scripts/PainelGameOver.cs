using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    [Header("Transição de cena")]
    [SerializeField]private string nomeCena;

    private void Start(){

        
        SoundManager.Instance.MusicaGameOver();
    }
    
    void Update()
    {
        ReceberInputs();
        
    }

    void ReceberInputs(){

        if(Input.GetKeyDown(KeyCode.R)){

            ReiniciarFase();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){

            VoltarMenu();
        }
    }

    void ReiniciarFase(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VoltarMenu(){

        SceneManager.LoadScene(nomeCena);
    }
}
