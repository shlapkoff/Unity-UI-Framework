using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IndigoBunting.FrameworkUI
{
    public class UIPopupView : UIBaseView
    {
        private RectTransform background;
        private RectTransform content;

        public override void Initialize(UIBaseCanvas uiCanvas)
        {
            this.background = transform.GetChild(0).GetComponent<RectTransform>();
            this.content = transform.GetChild(1).GetComponent<RectTransform>();
            
            base.Initialize(uiCanvas);
        }

        public RectTransform Background => background;
        public RectTransform Content => content;
    }
}
