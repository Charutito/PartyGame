using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUtils;

public class UIManager : SingletonObject<UIManager>
{
    public GameObject startMenu;
    public InputField usernameField;
    public InputField ipField;
    public InputField portField;

    /// <summary>Attempts to connect to the server.</summary>
    public void ConnectToServer()
    {
        startMenu.SetActive(false);
        usernameField.interactable = false;
        ipField.interactable = false;
        portField.interactable = false;
        Client.Instance.ConnectToServer();
    }
}
