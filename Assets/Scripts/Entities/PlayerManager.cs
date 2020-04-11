using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillSystem;

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
    [SerializeField] private GameObject skillFX;
    //SKILLS
    public SkillDefinition currentSkill;

    public Vector3 realpos;

    public Vector3 worldPosition;
    public GameObject worldPositionHolder;

    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, realpos, 0.25f);

        SetRotation();
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

    public void SetSkill(string skillId)
    {
        Debug.Log("--- Player " + id + " now have the skill: " + skillId);
        currentSkill = SkillSpawnerManager.Instance.GetSkill(skillId);
    }

    public void SetRotation()
    {
        //Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - skillFX.transform.position;

        //direction.Normalize();
        //float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Vector3 normal = Vector3.up.normalized;
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        worldPositionHolder.transform.position = worldPosition;
        //worldPosition.Normalize();
        //Debug.Log(worldPosition);
        Vector3 direction = worldPosition - skillFX.transform.position;
        skillFX.transform.LookAt(new Vector3(direction.x, transform.position.y, direction.z));


        //float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //skillFX.transform.rotation = Quaternion.AngleAxis(rotationZ, Vector3.forward);
        //skillFX.transform.Rotate(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}
