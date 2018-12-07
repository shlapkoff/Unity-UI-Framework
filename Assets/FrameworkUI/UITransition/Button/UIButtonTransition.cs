using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IndigoBunting.FrameworkUI
{
    public abstract class UIButtonTransition : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        protected UIButton button;
        protected Sequence animInstance;
        
        public virtual void Initialize(UIButton uiButton)
        {
            this.button = uiButton;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            
        }
        
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            
        }
    }
}