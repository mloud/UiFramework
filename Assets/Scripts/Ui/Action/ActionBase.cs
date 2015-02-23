using System;
using System.Collections.Generic;


namespace Ui.Action
{
    [System.Serializable]
    public class ActionBase : Core.MonoBehaviourGod
    {
        // Name of action
        public string Name;
        // trigger event
        public Ui.Evt.Types Type;
        // param of trigger
        public string Param;
        // delay before start
        public float Delay = 0.0f;

        public void Run()
        {
            Invoke("OnRun", Delay);
        }

        protected virtual void OnRun()
        {}


        private void Start()
        {
            Evt.Event.Register(OnEventReceived);  
        }

        private void OnDestroy()
        {
            Evt.Event.Unregister(OnEventReceived);
        }

        protected virtual void OnEventReceived(Evt.Event evt)
        { }


    }
}
