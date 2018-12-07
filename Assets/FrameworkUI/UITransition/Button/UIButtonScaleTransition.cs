using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IndigoBunting.FrameworkUI
{
    public class UIButtonScaleTransition : UIButtonTransition
    {
        [SerializeField] private RectTransform scaleRectTr;
        [SerializeField] private Vector3 scaleTo = new Vector3(0.94f, 0.94f, 0.94f);
        [SerializeField] private float scaleDuration = 0.1f;

        private Vector3 scaleDefault;
        
        public override void Initialize(UIButton uiButton)
        {
            scaleDefault = scaleRectTr.localScale;
            
            base.Initialize(uiButton);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            scaleRectTr.DOScale(scaleTo, scaleDuration);
            
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            scaleRectTr.DOScale(scaleDefault, scaleDuration);
            
            base.OnPointerUp(eventData);
        }
    }
}