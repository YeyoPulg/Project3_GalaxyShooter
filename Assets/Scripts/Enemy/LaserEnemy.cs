using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    private float velocidad = 10;
    [SerializeField] private float daño;

    private void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("nave"))
        {
            Player playerController = other.gameObject.GetComponent<Player>();
            playerController.Hurt(1);
            //other.GetComponent<Enemy>().TomarDaño(daño);
            Destroy(gameObject);
        }
    }
}

