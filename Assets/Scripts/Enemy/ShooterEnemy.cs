using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float spawntime = 2.5f;
    private float timeElapsed;


    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawntime)
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        timeElapsed = 0f;
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
    
//[SerializeField] float speed;
    //private bool isDestroyed;


    //private void OnEnable()
    //{
    //    isDestroyed = false;
    //    StartCoroutine(Shooting());
    //}

    //IEnumerator Shooting()
    //{
    //    float time = Random.Range(0.5f, 2.5f);
    //    yield return new WaitForSeconds(time);
    //    if (isDestroyed == false)
    //    {
    //        Instantiate(Resources.Load("LaserEnemy"), transform.position, Quaternion.identity);
    //    }
    //}

