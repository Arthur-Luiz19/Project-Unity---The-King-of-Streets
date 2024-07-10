using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PulaIntrodução : MonoBehaviour
{
    [Header("Pular Cena")]
    public GameObject GameObject;

    void Update()
    {   
        if(Input.GetButtonDown("Jump")){

            SceneManager.LoadScene("Stage1_Part01");
        }
    }

    
}
