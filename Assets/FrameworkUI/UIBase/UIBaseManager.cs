using System.Collections.Generic;
using UnityEngine;

namespace IndigoBunting.FrameworkUI
{
    public class UIBaseManager : MonoBehaviour
    {
        [SerializeField] protected Camera uiCamera;
        protected List<UIBaseCanvas> listOfCanvases;

        private void Awake()
        {
            if (uiCamera == null)
            {
                uiCamera = Camera.main;
            }
            
            listOfCanvases = new List<UIBaseCanvas>(GetComponentsInChildren<UIBaseCanvas>(true));
            
            foreach (var screen in listOfCanvases)
            {
                screen.Initialize(this);
            }
        }

        protected UIBaseCanvas GetCanvasByName(string name)
        {
            return listOfCanvases.Find(x => x.name.Equals(name));
        }

        public Camera UICamera
        {
            get 
            {
                if (uiCamera == null)
                {
                    uiCamera = Camera.main;
                }
                
                return uiCamera;
            }
        }

        public List<UIBaseCanvas> ListOfCanvases => listOfCanvases;
    }
}

