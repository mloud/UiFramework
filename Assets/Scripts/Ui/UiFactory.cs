using System;
using UnityEngine;

namespace Ui
{
    public class UiFactory : Core.MonoBehaviourGod, IUIFactory
    {
        [SerializeField]
        string windowsPrefabPath;

        [SerializeField]
        string componentsPrefabPath;


        protected override void Awake()
        {
            base.Awake();

            if (!windowsPrefabPath.EndsWith("/"))
                windowsPrefabPath += "/";

            if (!componentsPrefabPath.EndsWith("/"))
                componentsPrefabPath += "/";
        }

        public static UiFactory CreateInstance()
        {
            return Core.App.Instance.Res.Instantiate<UiFactory>("Prefabs/Ui/UiFactory");
        }


        public T Create<T>(string uiComponent) where T : Core.MonoBehaviourGod
        {
            T component = null;

            
            // Window
            if (typeof(T) == typeof(WindowController))
            {
                component = Core.App.Instance.Res.Instantiate<T>(windowsPrefabPath + uiComponent);
            }
            // Window background
            else if (typeof(T) == typeof(WindowBackground))
            {
                component = Core.App.Instance.Res.Instantiate<T>(componentsPrefabPath + uiComponent); 
            }


            if (component != null)
                component.gameObject.name = uiComponent;

            return component;
        }

        public void Set(GameObject go)
        {

        }
    }
}
