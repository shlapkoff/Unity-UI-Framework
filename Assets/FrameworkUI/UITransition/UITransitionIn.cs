using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace IndigoBunting.FrameworkUI
{
    public abstract class UITransitionIn : MonoBehaviour
    {
        protected UIBaseView view;
        protected Sequence animInstance;
        protected UnityAction startAnimCallback;
        protected UnityAction endAnimCallback;

        [SerializeField] protected float duration = 0.6f;
        
        public virtual void Initialize(UIBaseView view, UnityAction startAnimCallback, UnityAction endAnimCallback)
        {
            this.view = view;
            this.startAnimCallback = startAnimCallback;
            this.endAnimCallback = endAnimCallback;
        }

        public virtual void InitialState()
        {
            
        }
        
        public virtual void EndState()
        {
            
        }

        public virtual void Anim()
        {
            startAnimCallback?.Invoke();
            endAnimCallback?.Invoke();
        }

        public void KillAnim()
        {
            if (IsPlaying())
            {
                animInstance.Kill(true);
            }
        }

        public bool IsPlaying()
        {
            return animInstance != null && (animInstance.IsActive() && animInstance.IsPlaying());
        }
    }
}