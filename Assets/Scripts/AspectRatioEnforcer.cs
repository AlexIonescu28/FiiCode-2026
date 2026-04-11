using UnityEngine;

public class AspectRatioEnforcer : MonoBehaviour
{
    void Start()
    {
        // Proporția dorită (16:9)
        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        // Creează automat o cameră de fundal pentru barele negre
        Camera backgroundCam = new GameObject("BlackBackgroundCamera").AddComponent<Camera>();
        backgroundCam.depth = camera.depth - 1; // O punem fix în spatele camerei principale
        backgroundCam.clearFlags = CameraClearFlags.SolidColor;
        backgroundCam.backgroundColor = Color.black;
        backgroundCam.cullingMask = 0; // O setăm să NU randeze nimic din joc, doar ecranul negru

        // Aplicăm tăierea (Letterboxing) pe camera principală
        if (scaleheight < 1.0f)
        {
            // Ecran prea înalt (ex: 16:10) -> adaugă bare negre sus și jos
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            // Ecran prea lat (ex: Ultrawide) -> adaugă bare negre stânga și dreapta
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