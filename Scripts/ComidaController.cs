using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaController : MonoBehaviour
{
    [Header("Ganhar Vida")]
    public int ganharVida;
    
    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.GetComponent<VidaController>() != null){

            other.gameObject.GetComponent<VidaController>().AumentarVida(ganharVida);
            SoundManager.Instance.pegarComida.Play();
            Destroy(gameObject);
        }
    }
    
}
