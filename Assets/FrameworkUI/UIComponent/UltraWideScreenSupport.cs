using UnityEngine;
using UnityEngine.UI;

namespace IndigoBunting.FrameworkUI
{
    [RequireComponent(typeof(UIBaseManager))]
    public class UltraWideScreenSupport : MonoBehaviour
    {
        private void Start()
        {
            float defaultRatio = 9f / 16.2f;
            float ratio = (float)Screen.width / (float)Screen.height;

            if (ratio < defaultRatio)
            {
                UIBaseManager uiManager = GetComponent<UIBaseManager>();
                Camera uiCamera = uiManager.UICamera;
                
                Debug.Log("Safe area: x: " + Screen.safeArea.x + ", y: " + Screen.safeArea.y 
                          + ", width: " + Screen.safeArea.width + ", height: " + Screen.safeArea.height);

                Rect safeArea = Screen.safeArea;
                //Rect safeArea = new Rect(0, 102, 1125, 2202);
                foreach (var screen in uiManager.ListOfCanvases)
                {
                    var canvasScaler = screen.Canvas.GetComponent<CanvasScaler>();
                    var root = screen.Root;
                    Vector2 referenceResolution = canvasScaler.referenceResolution;
                    float offsetTop = ToAnotherSystemValue(safeArea.y, 0.0f, Screen.height, 0.0f,
                        referenceResolution.y);
                    
                    float offsetBottom = ToAnotherSystemValue((Screen.height - safeArea.height) / 2.0f, 0.0f, 
                        Screen.height, 0.0f, referenceResolution.y);
                    
                    root.offsetMin = new Vector2(0.0f, offsetTop);
                    root.offsetMax = new Vector2(0.0f, offsetBottom * -1f);
                    
                    //canvasScaler.matchWidthOrHeight = Mathf.Clamp01(canvasScaler.matchWidthOrHeight - ((defaultRatio - ratio) * 3f));
                }

                uiCamera.orthographicSize = uiCamera.orthographicSize + ((defaultRatio - ratio) * 10f);
            }
        }
        
        private float ToAnotherSystemValue(float currFrom, float minFrom, float maxFrom, float minTo, float maxTo)
        {
            float result = 0f;
            float p = (currFrom - minFrom) / (maxFrom - minFrom);
            result = ((maxTo - minTo) * p) + minTo;
            return result;
        }
    }
}
