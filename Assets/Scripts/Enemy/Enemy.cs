using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float vida;
    //[SerializeField] private GameObject efectoMuerte;

    public float velocidad = 5;

    // Update is called once per frame
    void Update()
    {
        movimineto();
    }

    void movimineto()
    {
        transform.position += Vector3.down * velocidad * Time.deltaTime; //DIRRECCIÓN DONDE SE MUEVE EL OBSTACULO
    }

    //public void TomarDaño(float daño)
    //{
    //    vida -= daño;

    //    if (vida <= 0)
    //    {
    //        Destroy(gameObject);
    //        //Muerte();
    //    }
    //}

    //private void Muerte()
    //{
    //    Instantiate(efectoMuerte, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "laser")
        {
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
        if (other.tag == "nave")
        {
            Player playerController = other.gameObject.GetComponent<Player>();
            playerController.Hurt(2);
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
