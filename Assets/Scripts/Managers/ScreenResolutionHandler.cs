using UnityEngine;

public class ScreenResolutionHandler : MonoBehaviour
{
    void Start()
    {
        // Ortak bir en-boy oranı belirleyin
        float targetAspect = 9.0f / 16.0f;

        // Mevcut ekranın en-boy oranını alın
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Ölçek faktörü
        float scaleHeight = windowAspect / targetAspect;

        // Kamera bileşenini alın
        Camera camera = Camera.main;

        // Ekran oranına göre ayarlama
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
