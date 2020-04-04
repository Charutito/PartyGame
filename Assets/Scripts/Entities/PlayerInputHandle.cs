using Managers;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        float[] _inputs = new float[]
        {
            InputManager.Instance.AxisHorizontal,
            InputManager.Instance.AxisVertical,
        };

        if (InputManager.Instance.CastSkill)
        {
            ClientSend.PlayerShoot(GameManager.Instance.localPlayerPrefab.transform.position, playerManager.currentSkill.Name);
        }

        ClientSend.PlayerMovement(_inputs);
    }
}
