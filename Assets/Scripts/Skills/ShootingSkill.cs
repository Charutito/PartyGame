using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillSystem.Skills
{
    public class ShootingSkill : SkillBehavior
    {


        private void Start()
        {
            StartCoroutine("DestroySkill");
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, realPos, 0.25f);
        }

        IEnumerator DestroySkill()
        {
            yield return new WaitForSeconds(Definition.DestroyAfterTime);
            GameManager.allSkills.Remove(UniqueId);
            Destroy(this.gameObject);   
        }
        
    }
}