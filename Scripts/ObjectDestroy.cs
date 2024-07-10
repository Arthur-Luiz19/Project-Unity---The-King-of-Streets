using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [Header("Objetos")]
    private SpriteRenderer  spriteRenderer;
    public  Sprite          brokenObject;

    [Header("Comidas")]
    public float            dropChance;
    public  GameObject[]    Comidas;

    [Header("Vida")]
    public  int             maxVida;
    private int             atualVida;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        atualVida = maxVida;
    }

    public void Broken(int DanoObjeto){

            atualVida -= DanoObjeto;
            Debug.Log("Objeto danificado");

            if(atualVida <=  2 && brokenObject != null){

                spriteRenderer.sprite = brokenObject;
                
                if(atualVida <= 0){
                    
                    SpawnComida();
                    StartCoroutine(BlinkAndDestroy());
                }
            }
    }

    IEnumerator BlinkAndDestroy(){

        for(float i = 0; i < 1; i += 0.2f){

             spriteRenderer.enabled = false;
             yield return new WaitForSeconds(0.1f);
             spriteRenderer.enabled = true;
             yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
                
    }

    void SpawnComida(){

        int numeroAleatorio = Random.Range(0, 101);
        
        if(numeroAleatorio <= dropChance){

            GameObject comidaEscolhida = Comidas[Random.Range(0, Comidas.Length)];
            Instantiate(comidaEscolhida, transform.position, Quaternion.identity);
        }
    }
}

