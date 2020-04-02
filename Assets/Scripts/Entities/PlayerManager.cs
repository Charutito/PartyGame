using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float health;
    public float maxHealth = 100f;
    public int itemCount = 0;

    [SerializeField]
    private GameObject shadowFX;
    [SerializeField]
    private GameObject rendererFX;
        
    public Vector3 realpos;

    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, realpos, 0.25f);
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        health = maxHealth;
    }

    public void SetHealth(float _health)
    {
        health = _health;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO animacion de muerte
        shadowFX.SetActive(false);
        rendererFX.SetActive(false);
    }

    public void Respawn()
    {
        SetHealth(maxHealth);
        shadowFX.SetActive(true);
        rendererFX.SetActive(true);
    }
}
