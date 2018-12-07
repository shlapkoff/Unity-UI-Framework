using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace IndigoBunting.FrameworkUI
{
    public class UIButton : MonoBehaviour, IPointerClickHandler
    {
        [Serializable] public class ButtonClickedEvent : UnityEvent { }
        
        [Header("Click Handler")]
        [FormerlySerializedAs("onClick")]
        [SerializeField] private ButtonClickedEvent onClick = new ButtonClickedEvent();
        
        private bool isEnable = true;
        private RectTransform rectTr;
        private UIButtonTransition transition;

        private void Awake()
        {
            transition = GetComponent<UIButtonTransition>();
            if (transition != null)
            {
                transition.Initialize(this);
            }
        }
        
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!isEnable) return;

            onClick?.Invoke();
        }

        public void SetEnable(bool enable)
        {
            this.isEnable = enable;
        }
        
        public RectTransform RectTr
        {
            get
            {
                if (rectTr == null) rectTr = GetComponent<RectTransform>();
                return rectTr;
            }
        }
    }
}