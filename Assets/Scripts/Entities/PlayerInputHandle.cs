using Managers;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    private PlayerManager playerManager;

    private Vector3 worldPosition;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void FixedUpdate()
    {
        GetWorldPosition();
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
        ClientSend.PlayerSkillRotation(worldPosition);
    }

    private void GetWorldPosition()
    {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.MousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
    }
}
