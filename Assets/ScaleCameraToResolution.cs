using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Camera
{
    public class ScaleCameraToResolution : MonoBehaviour
    {

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            // http://answers.unity3d.com/questions/32229/how-do-i-set-the-aspect-ratio-of-the-viewport.html
            // set the desired aspect ratio (the values in this example are
            // hard-coded for 16:9, but you could make them into public
            // variables instead so you can set them at design time)
            const float targetaspect = 16.0f / 9.0f;

            // determine the game window's current aspect ratio
            float windowaspect = Screen.width / (float)Screen.height;

            // current viewport height should be scaled by this amount
            float scaleheight = windowaspect / targetaspect;

            // obtain camera component so we can modify its viewport
            var cameraComponent = GetComponent<UnityEngine.Camera>();

            // if scaled height is less than current height, add letterbox
            if (scaleheight < 1.0f)
            {
                Rect rect = cameraComponent.rect;

                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f - scaleheight) / 2.0f;

                cameraComponent.rect = rect;
            }
            else // add pillarbox
            {
                float scalewidth = 1.0f / scaleheight;

                Rect rect = cameraComponent.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

                cameraComponent.rect = rect;
            }
        }
    }
}
