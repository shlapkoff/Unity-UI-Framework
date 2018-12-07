using System;
using UnityEngine;

namespace IndigoBunting.FrameworkUI
{
    public class UIBaseCanvas : MonoBehaviour
    {
        protected UIBaseManager manager;
        protected UIBaseView[] views;
        protected RectTransform root;
        protected Canvas canvas;

        private int countHidingViews = 0;
        
        public virtual void Initialize(UIBaseManager manager)
        {
            this.manager = manager;
            this.root = transform.GetChild(0).GetComponent<RectTransform>();
            this.views = root.GetComponentsInChildren<UIBaseView>(true);
            this.canvas = GetComponent<Canvas>();
            
            foreach (var view in views)
            {
                view.Initialize(this);
                view.OnStartShowingEvent += View_OnStartShowingEvent;
                view.OnEndHidingEvent += View_OnEndHidingEvent;
            }
        }

        private void View_OnStartShowingEvent(object sender, EventArgs e)
        {
            countHidingViews = 0;
            gameObject.SetActive(true);
        }

        private void View_OnEndHidingEvent(object sender, EventArgs e)
        {
            countHidingViews++;

            if (countHidingViews == views.Length)
            {
                gameObject.SetActive(false);
            }
        }

        [HideInInspector]
        public virtual void Show()
        {
            foreach (var view in views)
            {
                view.Show();
            }
        }
        
        [HideInInspector]
        public virtual void Hide()
        {
            foreach (var view in views)
            {
                view.Hide();
            }
        }

        public UIBaseManager UIManager
        {
            get { return manager; }
        }

        public RectTransform Root
        {
            get { return root; }
        }
        
        public Canvas Canvas
        {
            get
            {
                if (canvas == null)
                {
                    canvas = GetComponent<Canvas>();
                }

                return canvas;
            }
        }
    }
}