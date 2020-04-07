using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Skills/PickupableSkillDefinition")]
public class PickupableSkillDefinition : ScriptableObject
{
    [Header("Pickupable skills Name and Prefab")]
    [SerializeField]
    public List<SkillPickupNames> skillsPrefabs;
}