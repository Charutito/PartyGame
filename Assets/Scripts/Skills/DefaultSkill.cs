using System.Collections;
using UnityEngine;

namespace SkillSystem.Skills
{
    public class DefaultSkill : SkillBehavior
    {
        private void Start()
        {
            StartCoroutine("DestroySkill");
        }

        IEnumerator DestroySkill()
        {
            yield return new WaitForSeconds(Definition.DestroyAfterTime);
            GameManager.allSkills.Remove(UniqueId);
            Destroy(this.gameObject);
        }
    }
}
