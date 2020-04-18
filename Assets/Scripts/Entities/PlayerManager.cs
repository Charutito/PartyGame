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
    [SerializeField] private GameObject skillPivot;
    //SKILLS
    public SkillDefinition currentSkill;

    public Vector3 realpos;
    public Vector3 worldPosition;

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
        currentSkill = SkillSpawnerManager.Instance.GetSkill(skillId);
        Destroy(skillPivot.transform.GetChild(0));
        Instantiate(currentSkill.TexturePrefab, skillPivot.transform);
    }

    public void SetRotation()
    {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        Vector3 direction = worldPosition - transform.position;
        direction.y = 0f;
        skillPivot.transform.right = direction;
    }
}
