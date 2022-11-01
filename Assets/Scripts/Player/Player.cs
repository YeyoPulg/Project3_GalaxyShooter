using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float velocidad;
    public GameObject laser;
    private Shooter shooter;
    private bool isAlive;
    private SpriteRenderer playerSprite;
    [SerializeField] private int playerLife;

    private AudioSource disparo;
    public Scena scena;
    private Rigidbody2D rb;
    public GameObject[] life;
    //public GameObject explosion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shooter = GetComponentInChildren<Shooter>();
        playerSprite = GetComponent<SpriteRenderer>();
        disparo= GetComponent<AudioSource>();
    }

    private void Start()
    {
        life[0].SetActive(true);
        life[1].SetActive(false);
        life[2].SetActive(false);
        life[3].SetActive(false);
        isAlive = true;
        playerLife = life.Length;
    }
    private void Update()
    {
        Shooting();
    }

    private void FixedUpdate()
    {
        
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (isAlive)
        {
            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(movX, movY) * velocidad;
        }
    }
    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //playerSound.Play();
            shooter.Shooting();
            disparo.Play();
        }
    }

    public void Hurt(int hurt)
    {
        playerLife -= hurt;

        if (playerLife <= 0)
        {
            Destroy(life[2]);
            life[3].SetActive(true);
            isAlive = false;
            playerSprite.enabled = false;
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
            scena.Perder();
        }
        else if (playerLife == 2)
        {
            Destroy(life[0]);
            life[1].SetActive(true);
        }
        else if (playerLife == 1)
        {
            Destroy(life[1]);
            life[2].SetActive(true);
        }
    }
}
