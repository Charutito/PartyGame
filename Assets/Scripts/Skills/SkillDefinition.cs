using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SkillSystem
{
    [CreateAssetMenu(menuName = "Gameplay/Skills/New Skill")]
    public class SkillDefinition : ScriptableObject
    {
        [Header("UI")]
        public string Name = string.Empty;
        public Texture2D Texture;

        [Header("Cast")]
        public GameObject Prefab;
        [SerializeField]
        public SkillBehavior Behavior;
        //add any effects, cooldowns or costs here.

        [Header("Damage")]
        public int Damage;

        [Header("Projectile")]
        public GameObject ProjectilePrefab;
        public float Speed;
        public float DestroyAfterTime = 2f;
        public bool DestroyOnCollision = true;

        public GameObject Cast(SkillDefinition _definition, Vector3 _position, Quaternion _rotation, Transform _parent = null)
        {
            return Instantiate(_definition.Prefab, _position, _rotation, _parent);
        }

        public SkillBehavior Cast(SkillBehavior _behavior, Vector3 _position, Quaternion _rotation, Transform _parent = null)
        {
            return Instantiate(_behavior, _position, _rotation, _parent);
        }
    }
}