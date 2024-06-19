using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    
    public Transform    plataforma, pontoA, pontoB;
    public float        velocidadeMove;
    public Vector3      pontoDestino;

    // Start is called before the first frame update
    void Start()
    {
        
        plataforma.position = pontoA.position;
        pontoDestino = pontoB.position;

    }

    // Update is called once per frame
    void Update()
    {
        plataforma.position = Vector3.MoveTowards(plataforma.position, pontoDestino, velocidadeMove * Time.deltaTime);
        
        if(plataforma.position == pontoA.position){
            pontoDestino = pontoB.position;
        }

        else if(plataforma.position == pontoB.position){
            pontoDestino = pontoA.position;
        }
    }
}
