using SkillSystem;
using System;
using UnityEngine;

[Serializable]
public class SkillPickupNames
{
    [SerializeField]
    public string SkillName;
    [SerializeField]
    public PickupableSkill SkillPickupPrefab;
    [SerializeField]
    public SkillDefinition SkillPrefab;
}
