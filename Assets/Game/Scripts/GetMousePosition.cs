using System.Collections;
using UnityEngine;

public static class GetMousePosition
{
    public static MousePositionData Get()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float rayLength))
        {
            return new MousePositionData(true, ray.GetPoint(rayLength));
        }

        return new NullMousePositionData();
    }
}

public class MousePositionData
{
    public bool hasMousePosition;
    public Vector3 position;

    public MousePositionData(bool hasPosition, Vector3 pos)
    {
        hasMousePosition = hasPosition;
        position = pos;
    }
}

public class NullMousePositionData : MousePositionData
{
    public NullMousePositionData() : base(false, Vector3.zero) 
    { 
    
    }
}