using Console;
using GameUtils;
using Managers;
using SkillSystem;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public static Dictionary<string, SkillBehavior> allSkills = new Dictionary<string, SkillBehavior>();

    [SerializeField] private CameraFollow camera;
    [SerializeField] public GameObject localPlayerPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject itemSpawnerPrefab;
    [SerializeField] private DeveloperConsole consolePrefab;

    private DeveloperConsole consoleInstance;

    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.Instance.myId = _myId;
        ClientSend.WelcomeReceived();

        // Now that we have the client's id, connect UDP
        Client.Instance.udp.Connect(((IPEndPoint)Client.Instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    /// <summary>Spawns a player.</summary>
    /// <param name="_id">The player's ID.</param>
    /// <param name="_name">The player's name.</param>
    /// <param name="_position">The player's starting position.</param>
    /// <param name="_rotation">The player's starting rotation.</param>
    public void SpawnPlayer(int _id, string _username, Vector3 _position)
    {
        GameObject _player;
        if (_id == Client.Instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, Quaternion.identity);
            camera.target = _player.transform;
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, Quaternion.identity);
        }

        _player.GetComponent<PlayerManager>().Initialize(_id, _username);
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    void Update()
    {
        CallConsole();
    }

    void CallConsole()
    {
        if (InputManager.Instance.OpenConsole)
        {
            if (consoleInstance != null)
            {
                consoleInstance.consoleCanvas.gameObject.SetActive(!consoleInstance.consoleCanvas.gameObject.activeInHierarchy);
            }
            else
            {
                consoleInstance = Instantiate(consolePrefab, consolePrefab.transform.position, Quaternion.identity);
                consoleInstance.consoleCanvas.gameObject.SetActive(true);
            }
        }
    }
}
