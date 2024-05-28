using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector3 ScreenClamp(Vector2 position, Vector2 bounds)
    {
        position.x = Mathf.Clamp(position.x, -bounds.x, bounds.x);
        position.y = Mathf.Clamp(position.y, -bounds.y, bounds.y);
        return position;
    }
    public static Vector2 GetScreenBounds()
    {
        return GetScreenBounds(Camera.main);
    }
    public static Vector2 GetScreenBounds(Camera cam)
    {
        // Viewport'un sağ üst köşesini Dünya koordinatlarına dönüştür
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        // Yalnızca X (sağ sınır) ve Y (üst sınır) değerlerini al ve bir Vector2 olarak döndür
        return new Vector2(topRight.x, topRight.y);
    }

}
