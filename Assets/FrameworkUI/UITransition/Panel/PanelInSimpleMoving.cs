using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace IndigoBunting.FrameworkUI.Panel
{
    [RequireComponent(typeof(UIPanelView))]
    public class PanelInSimpleMoving : UITransitionIn
    {
        private CanvasGroup canvasGroup;
        
        [SerializeField] private Vector2 initialAnchoredPosition = new Vector2(0f, 1200f);
        [SerializeField] private Vector2 endAnchoredPosition = new Vector2(0f, 0f);
        [SerializeField] private Ease popupEase = Ease.OutBack;
        
        public override void Initialize(UIBaseView view, UnityAction startAnimCallback, UnityAction endAnimCallback)
        {
            UIPanelView panelView = (UIPanelView) view;
            
            canvasGroup = panelView.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = panelView.gameObject.AddComponent<CanvasGroup>();
            }
            
            base.Initialize(view, startAnimCallback, endAnimCallback);
        }
        
        public override void InitialState()
        {
            UIPanelView panelView = (UIPanelView) view;
            
            panelView.RectTr.anchoredPosition = initialAnchoredPosition;
            
            base.InitialState();
        }
        
        public override void EndState()
        {
            UIPanelView panelView = (UIPanelView) view;
            
            panelView.RectTr.anchoredPosition = endAnchoredPosition;
            
            base.EndState();
        }
        
        public override void Anim()
        {
            KillAnim();
            
            UIPanelView panelView = (UIPanelView) view;

            startAnimCallback?.Invoke();
            
            animInstance = DOTween.Sequence();
            
            animInstance.Insert(0.0f, canvasGroup.DOFade(1.0f, 0.2f).SetEase(Ease.Linear));
            animInstance.Insert(0.0f, panelView.RectTr.DOAnchorPos(endAnchoredPosition, duration).SetEase(popupEase));

            if (endAnimCallback != null)
            {
                animInstance.OnComplete(() => { endAnimCallback?.Invoke(); });
            }
        }
    }
}