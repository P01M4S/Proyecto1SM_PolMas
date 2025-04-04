using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour

{
public BoxCollider2D _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            PlayerControler playerScript = collision.gameObject.GetComponent<PlayerControler>();
            playerScript.Death();
        }
    
    }

}
