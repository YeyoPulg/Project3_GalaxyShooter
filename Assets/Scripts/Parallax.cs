using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Vector2 velocidad; //ES LA VELOCIDA CON LA QUE QUIERO QUE SE MUEVA

    private Vector2 offset;
    private Material material; //HACEMOS REFERENCIA AL MATERIAL

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material; //EL MATERIAL DEBE SER EL MISMO QUE EL 'Renderer'   
    }

    // Update is called once per frame
    void Update()
    {
        offset = velocidad * Time.deltaTime; //EL offset ES IGUAL AL TIEMPO TOMADO
        material.mainTextureOffset += offset; //SUMAR EL offset ya creado
    }
}
