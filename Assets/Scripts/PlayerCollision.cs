﻿using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    [SerializeField] PlayerMovement playerMovement = default;
    [SerializeField] Material fullHealth = default;
    [SerializeField] Material mediumHealth = default;
    [SerializeField] Material lowHealth = default;
    [SerializeField] GameObject playerParticle = default;

    [SerializeField] AudioClip hit = default;
    [SerializeField] AudioClip destroy = default;

    int lives = 3;
    int numberOfParticlesInExplosion = 3;

    void Start()
    {
        GetComponent<Renderer>().material = fullHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            lives--;
            switch (lives)
            {
                case 2:
                    GetComponent<AudioSource>().PlayOneShot(hit);
                    GetComponent<Renderer>().material = mediumHealth;
                    break;
                case 1:
                    GetComponent<AudioSource>().PlayOneShot(hit);
                    GetComponent<Renderer>().material = lowHealth;
                    break;
                case 0:
                    GetComponent<AudioSource>().PlayOneShot(destroy);
                    DestroyPlayer();
                    playerMovement.enabled = false;
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finishLine"))
        {
            gameManager.FinishLineHit();
        }
    }

    void DestroyPlayer()
    {
        GetComponent<Renderer>().enabled = false;
        for (int x = -numberOfParticlesInExplosion; x < numberOfParticlesInExplosion; x++)
        {
            for (int y = -numberOfParticlesInExplosion; y < numberOfParticlesInExplosion; y++)
            {
                for (int z = -numberOfParticlesInExplosion; z < numberOfParticlesInExplosion; z++)
                {
                    float xPosition = transform.position.x + x / numberOfParticlesInExplosion;
                    float yPosition = transform.position.y + y / numberOfParticlesInExplosion;
                    float zPosition = transform.position.z + z / numberOfParticlesInExplosion;
                    Vector3 position = new Vector3(xPosition, yPosition, zPosition);
                    _ = Instantiate(playerParticle, position, Quaternion.identity);
                }
            }
        }
    }

}
