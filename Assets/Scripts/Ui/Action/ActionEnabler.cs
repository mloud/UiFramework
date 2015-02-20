using System;
using System.Collections.Generic;
using UnityEngine;


namespace Ui.Action
{
    [System.Serializable]
    public class ActionEnabler : ActionBase
    {
        public bool Enable;
        public List<GameObject> GameObjects;

        protected override void OnRun()
        {
            foreach (var go in GameObjects)
                go.SetActive(Enable);
        }
    }
}
