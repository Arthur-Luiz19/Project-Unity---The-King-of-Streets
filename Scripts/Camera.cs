using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Referência ao transform do personagem

    public Vector3 offset; // Offset da câmera em relação ao personagem

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Posiciona a câmera na posição do personagem com um offset
            Vector3 targetPosition = target.position + offset;
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }
}
