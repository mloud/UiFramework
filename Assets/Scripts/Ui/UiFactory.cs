using System;
using UnityEngine;

namespace Ui
{
    public class UiFactory : Core.MonoBehaviourGod, IUIFactory
    {
        [SerializeField]
        string windowsPrefabPath;

        protected override void Awake()
        {
            base.Awake();

            if (!windowsPrefabPath.EndsWith("/"))
                windowsPrefabPath += "/";
        }

        public static UiFactory CreateInstance()
        {
            return Core.App.Instance.Res.Instantiate<UiFactory>("Prefabs/Ui/UiFactory");
        }


        public T Create<T>(string uiComponent) where T : Core.MonoBehaviourGod
        {
            T component = null;

            if (typeof(T) == typeof(WindowController))
            {
                component = Core.App.Instance.Res.Instantiate<T>(windowsPrefabPath + uiComponent);
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
