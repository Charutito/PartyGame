using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillSystem;
using System;

public class SkillHandle : MonoBehaviour
{
    public static void SkillPosition(Packet _packet)
    {
        string _uniqueId = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();

        GameManager.allSkills[_uniqueId].realPos = _position;
    }

    public static void SkillCasted(Packet _packet)
    {
        int _byPlayer = _packet.ReadInt();
        string _uniqueKey = _packet.ReadString();

        PlayerManager player = GameManager.players[_byPlayer];

        SkillBehavior behavior = player.currentSkill.Cast(player.currentSkill.Behavior, player.transform.position, Quaternion.identity);

        GameManager.allSkills.Add(_uniqueKey , behavior);
    }
}
