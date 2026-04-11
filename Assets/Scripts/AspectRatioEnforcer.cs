using UnityEngine;

public class AspectRatioEnforcer : MonoBehaviour
{
    void Start()
    {
        
        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        Camera backgroundCam = new GameObject("BlackBackgroundCamera").AddComponent<Camera>();
        backgroundCam.depth = camera.depth - 1;
        backgroundCam.clearFlags = CameraClearFlags.SolidColor;
        backgroundCam.backgroundColor = Color.black;
        backgroundCam.cullingMask = 0;

        if (scaleheight < 1.0f)
        {
           
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;

            rect.y = 1.0f - scaleheight;

            camera.rect = rect;
        }
        else
        {
           
            float scalewidth = 1.0f / scaleheight;
            Rect rect = camera.rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}