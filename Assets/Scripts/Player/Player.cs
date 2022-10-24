using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float velocidad;

    private Vector2 movimiento;
    public GameObject laser;
    private Shooter shooter;
    private bool isAlive;
    //private EnemyController enemyController;
    private SpriteRenderer playerSprite;
    [SerializeField] private int playerLife;


    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shooter = GetComponentInChildren<Shooter>();
        //enemyController = FindObjectOfType<EnemyController>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        isAlive = true;
    }
    private void Update()
    {
        Shooting();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        //rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
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
        }
    }

    public void Hurt(int hurt)
    {
        playerLife -= hurt;
        //UIController.instance.SetLife(playerLife);

        if (playerLife <= 0)
        {
            isAlive = false;
            //UIController.instance.EndGameText("Game Over!");
            //enemyController.PlayerIsdead();
            playerSprite.enabled = false;
            //particles.Play();
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
