using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform _bullet;
    public GameObject bulletPrefab;
    public AudioClip Piw;
    public AudioSource _audioSource;

    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, _bullet.position, _bullet.rotation);
        _audioSource.PlayOneShot(Piw);
    }
}
