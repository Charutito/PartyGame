using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();

        GameManager.Instance.SpawnPlayer(_id, _username, _position);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        GameManager.players[_id].realpos = _position;
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = Quaternion.identity;

        GameManager.players[_id].transform.rotation = _rotation;
    }

    public static void PlayerDisconnected(Packet _packet)
    {
        int _id = _packet.ReadInt();

        Destroy(GameManager.players[_id].gameObject);
        GameManager.players.Remove(_id);
    }

    public static void PlayerHealth(Packet _packet)
    {
        int _id = _packet.ReadInt();
        float _health = _packet.ReadFloat();

        GameManager.players[_id].SetHealth(_health);
    }

    public static void PlayerRespawned(Packet _packet)
    {
        int _id = _packet.ReadInt();

        GameManager.players[_id].Respawn();
    }

    public static void CreatePickupableSkill(Packet _packet)
    {
        string skillId = _packet.ReadString();
        Vector3 spawnPosition = _packet.ReadVector3();

        SkillSpawnerManager.Instance.SpawnPickupableSkill(skillId, spawnPosition);
    }

    public static void SkillPickedUp(Packet _packet)
    {
        string skillId = _packet.ReadString();
        int _id = _packet.ReadInt();

        GameManager.players[_id].SetSkill(skillId);
    }
}
