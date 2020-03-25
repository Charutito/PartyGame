using Managers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            InputManager.Instance.AxisVertical
        };

        ClientSend.PlayerMovement(_inputs);
    }
}
