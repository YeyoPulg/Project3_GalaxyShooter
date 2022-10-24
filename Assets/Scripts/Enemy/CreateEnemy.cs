using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public float maxtime; //TIEMPO QUE DEMORA EN CREAR OBSTACULO
    private float initime = 0;
    public GameObject naveEnemy; //OBJETO PARA CREAR LOS OBSTACULOS
    //public float altura;
    private float limitleft = -8;
    private float limitrigth = 8;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (initime > maxtime)
            {
                GameObject newobstaculo = Instantiate(naveEnemy); //SIGUIENTE OBTACULO
                newobstaculo.transform.position = transform.position + new Vector3(Random.Range(limitleft, limitrigth), 0); //INSTANCIAMIENTO
                Destroy(gameObject, 100); //DESTRUCCIÓN DE OBSTACULO
                initime = 0;
            }
            else
            {
                initime += Time.deltaTime; //SI NO SE HA CUMPLIDO EL TIEMPO
            }
    }
}
