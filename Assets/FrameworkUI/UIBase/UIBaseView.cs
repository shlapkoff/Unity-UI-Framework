using System;
using UnityEngine;

namespace IndigoBunting.FrameworkUI
{
    public class UIBaseView : MonoBehaviour
    {
        private RectTransform rectTr;

        protected UIBaseCanvas uiCanvas;
        protected UITransitionIn animIn;
        protected UITransitionOut animOut;

        public virtual void Initialize(UIBaseCanvas uiCanvas)
        {
            this.uiCanvas = uiCanvas;
            
            animIn = GetComponent<UITransitionIn>();
            animOut = GetComponent<UITransitionOut>();

            if (animIn != null)
            {
                animIn.Initialize(this, OnStartShowing, OnEndShowing);
                animIn.InitialState();
            }
            
            if (animOut != null) animOut.Initialize(this, OnStartHiding, OnEndHiding);
        }

        [HideInInspector]
        public virtual void Show()
        {
            if (animOut != null) animOut.KillAnim();
            
            if (animIn != null)
            {
                animIn.Anim();
            }
            else
            {
                OnStartShowing();
                OnEndShowing();
            }
        }

        [HideInInspector]
        public virtual void Hide()
        {
            if (animIn != null) animIn.KillAnim();
            
            if (animOut != null)
            {
                animOut.Anim();
            }
            else
            {
                OnStartHiding();
                OnEndHiding();
            }
        }

        protected virtual void OnStartShowing()
        {
            gameObject.SetActive(true);
            OnStartShowingEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnEndShowing()
        {
            OnEndShowingEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnStartHiding()
        {
            OnStartHidingEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnEndHiding()
        {
            gameObject.SetActive(false);
            if (animOut != null) animOut.EndState();
            
            OnEndHidingEvent?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnStartShowingEvent;
        public event EventHandler OnEndShowingEvent;
        public event EventHandler OnStartHidingEvent;
        public event EventHandler OnEndHidingEvent;

        public RectTransform RectTr
        {
            get
            {
                if (rectTr == null) rectTr = GetComponent<RectTransform>();
                return rectTr;
            }
        }

        public UIBaseCanvas UICanvas => uiCanvas;
        public UIBaseManager UIManager => uiCanvas.UIManager;
    }
}