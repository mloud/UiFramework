using System;
using System.Collections.Generic;


namespace Ui.Action
{
    [System.Serializable]
    public class ActionBase : Core.MonoBehaviourGod
    {
        public Ui.Evt.Types Type;
        public string Param;
        public float Delay = 0.0f;

        public void Run()
        {
            Invoke("OnRun", Delay);
        }

        protected virtual void OnRun()
        {}

    }
}
