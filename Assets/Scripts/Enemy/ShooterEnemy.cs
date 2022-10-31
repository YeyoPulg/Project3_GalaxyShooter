using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float spawntime = 2.5f;
    private float timeElapsed;
    private AudioSource disparo;

    private void Awake()
    {
        disparo = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawntime)
        {
            Disparar();
            disparo.Play();
        }
    }

    private void Disparar()
    {
        timeElapsed = 0f;
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}

