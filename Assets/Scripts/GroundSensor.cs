using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    public Enemy _enemyScript;
    public Rigidbody2D _rigidBody;
    public float jumpDamage = 6;
    public PlayerControler playerControler;

    void Awake()
    {
    _rigidBody = GetComponentInParent<Rigidbody2D>();
    }

void OnTriggerEnter2D(Collider2D collider)
{
    if(collider.gameObject.layer == 3)
    {
        isGrounded = true;
        Debug.Log(collider.gameObject.name);
        Debug.Log(collider.gameObject.transform.position);
    }

    else if (collider.gameObject.layer == 6)
    {
        _rigidBody.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
        _enemyScript = collider.gameObject.GetComponent<Enemy>();
        _enemyScript.TakeDamage(jumpDamage);
    }

    if(collider.gameObject.layer == 10)
    {
        playerControler = GetComponentInParent<PlayerControler>();
        playerControler.Death();
    }

}

void OnTriggerStay2D(Collider2D collider) 
{
    if(collider.gameObject.layer == 3)
    {
    isGrounded = true;
    }
}

void OnTriggerExit2D(Collider2D collider)
{
    if(collider.gameObject.layer == 3)
    {
    isGrounded = false;
    }
}

}
