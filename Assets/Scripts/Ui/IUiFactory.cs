using System;
using UnityEngine;

namespace Ui
{
    public interface IUIFactory
    {
        T Create<T>(string uiComponent) where T : Core.MonoBehaviourGod;

        void Set(GameObject go);
    }
}
