using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private Canvas TargetCanvas;
    protected Vector2 _newPosition;

    protected virtual void LateUpdate()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(TargetCanvas.transform as RectTransform, Input.mousePosition, TargetCanvas.worldCamera, out _newPosition);
        transform.position = TargetCanvas.transform.TransformPoint(_newPosition);
    }
}