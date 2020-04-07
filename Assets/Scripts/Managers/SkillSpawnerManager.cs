using GameUtils;
using SkillSystem;
using UnityEngine;

public class SkillSpawnerManager : SingletonObject<SkillSpawnerManager>
{
    public PickupableSkillDefinition pickupableSkillDefinition;

    public void SpawnPickupableSkill(string skillId, Vector3 spawnPosition)
    {
        foreach (SkillPickupNames skill in pickupableSkillDefinition.skillsPrefabs)
        {
            if(skill.SkillName == skillId)
            {
                Instantiate(skill.SkillPickupPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    public SkillDefinition GetSkill(string skillId)
    {
        foreach (SkillPickupNames skill in pickupableSkillDefinition.skillsPrefabs)
        {
            return skill.SkillPrefab;
        }

        return null;
    }
}
