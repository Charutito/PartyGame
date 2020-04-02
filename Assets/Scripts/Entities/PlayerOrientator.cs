using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void Update()
    {
        if(InputManager.Instance.AxisMoving)
        {
            FaceDirection(InputManager.Instance.AxisHorizontal);
        }
    }

    /// <summary>
    /// Flips the character and its dependencies horizontally
    /// </summary>
    public void FaceDirection(float direction)
    {
        spriteRenderer.flipX = (direction == -1);
    }
}
