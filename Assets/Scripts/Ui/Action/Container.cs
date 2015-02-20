using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ui.Action
{
    public class Container : Core.MonoBehaviourGod
    {
      
        private List<ActionBase> Actions;

        protected override void Awake()
        {
            // gather all actions on the same component
          Actions = new List<ActionBase>(GetComponents<ActionBase>());
        }

        protected void OnEnable()
        {
            Evt.Event.Register(OnEventReceived);
        }

        protected void OnDisable()
        {
            Evt.Event.Unregister(OnEventReceived);
        }


        private void OnEventReceived(Evt.Event evt)
        {
            foreach (var action in Actions)
            {
                if (action.Type == evt.Type && action.Param == evt.Param)
                {
                    action.Run();
                }
            }
        }
    }
}
