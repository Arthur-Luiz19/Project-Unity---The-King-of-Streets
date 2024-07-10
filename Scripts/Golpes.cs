using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpes : MonoBehaviour
{
    
     [Header("Dar Dano")]
     public int danoGolpe;

     void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.GetComponent<VidaController>() != null){

            other.gameObject.GetComponent<VidaController>().LevarDano(danoGolpe);
        }

        else if(other.gameObject.GetComponent<VidaInimigo_2>() != null){

            other.gameObject.GetComponent<VidaInimigo_2>().InimigoLevarDano_2(danoGolpe);
        }

        else if(other.gameObject.GetComponent<VidaInimigo>() != null){

            other.gameObject.GetComponent<VidaInimigo>().InimigoLevarDano(danoGolpe);
        }

        else if(other.gameObject.GetComponent<ObjectDestroy>() != null){

            other.gameObject.GetComponent<ObjectDestroy>().Broken(danoGolpe);
        }
     }
}
