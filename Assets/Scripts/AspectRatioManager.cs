using UnityEngine;

public class AspectRatioManager : MonoBehaviour
{
   public float targetWidth = 9f;
   public float targetHeight = 16f;

   private Camera mainCamera;

   private void Start()
   {
      mainCamera = GetComponent<Camera>();
      UpdateAspectRatio();
   }

   private void Update()
   {
      UpdateAspectRatio();
   }

   private void UpdateAspectRatio()
   {
      float targetAspect = targetWidth / targetHeight;
      float windowAspect = (float)Screen.width / (float)Screen.height;
      float scaleHeight = windowAspect / targetAspect;
      
      if (scaleHeight < 1.0f)
      {
         Rect rect = mainCamera.rect;
         rect.width = 1.0f;
         rect.height = scaleHeight;
         rect.x = 0;
         rect.y = (1.0f - scaleHeight) / 2.0f;
         mainCamera.rect = rect;
      }
      else
      {
         float scaleWidth = 1.0f / scaleHeight;
         Rect rect = mainCamera.rect;
         rect.width = scaleWidth;
         rect.height = 1.0f;
         rect.x = (1.0f - scaleWidth) / 2.0f;
         rect.y = 0;
         mainCamera.rect = rect;
      }
   }
}
