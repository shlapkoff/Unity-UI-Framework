using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace IndigoBunting.FrameworkUI
{
    [RequireComponent(typeof(UIPopupView))]
    public class PopupInSimpleMoving : UITransitionIn
    {
        private CanvasGroup cgBackground;
        private CanvasGroup cgContent;
        
        [Header("Moving values")]
        [SerializeField] private Vector2 initialAnchoredPosition = new Vector2(0f, 1200f);
        [SerializeField] private Vector2 endAnchoredPosition = new Vector2(0f, 0f);
        [SerializeField] private Ease popupEase = Ease.OutBack;
        
        [Header("Fade values")]
        [SerializeField] private float initialBackgroundFade = 0.0f;
        [SerializeField] private float endBackgroundFade = 0.6f;
        
        public override void Initialize(UIBaseView view, UnityAction startAnimCallback = null, UnityAction endAnimCallback = null)
        {
            UIPopupView popupView = (UIPopupView) view;
            
            cgBackground = popupView.Background.GetComponent<CanvasGroup>();
            if (cgBackground == null)
            {
                cgBackground = popupView.Background.gameObject.AddComponent<CanvasGroup>();
            }
            
            cgContent = popupView.Content.GetComponent<CanvasGroup>();
            if (cgContent == null)
            {
                cgContent = popupView.Content.gameObject.AddComponent<CanvasGroup>();
            }
            
            base.Initialize(view, startAnimCallback, endAnimCallback);
        }
        
        public override void InitialState()
        {
            UIPopupView popupView = (UIPopupView) view;
            
            popupView.Content.anchoredPosition = initialAnchoredPosition;
            cgContent.alpha = 0.0f;
            cgBackground.alpha = initialBackgroundFade;
            
            base.InitialState();
        }
        
        public override void EndState()
        {
            UIPopupView popupView = (UIPopupView) view;
            
            popupView.Content.anchoredPosition = endAnchoredPosition;
            cgContent.alpha = 1.0f;
            cgBackground.alpha = endBackgroundFade;
            
            base.EndState();
        }

        public override void Anim()
        {
            KillAnim();
            
            UIPopupView popupView = (UIPopupView) view;

            startAnimCallback?.Invoke();
            
            animInstance = DOTween.Sequence();
            
            animInstance.Insert(0.0f, cgContent.DOFade(1.0f, 0.2f).SetEase(Ease.Linear));
            animInstance.Insert(0.0f, popupView.Content.DOAnchorPos(endAnchoredPosition, duration).SetEase(popupEase));
            animInstance.Insert(0.0f, cgBackground.DOFade(endBackgroundFade, duration));

            if (endAnimCallback != null)
            {
                animInstance.OnComplete(() => { endAnimCallback?.Invoke(); });
            }
        }
    }
}