﻿using System;
using System.Collections.Generic;


namespace Ui.Evt
{
    public class Event
    {
        public Evt.Types Type { get; private set; }
        public string Param { get; private set; }

        public Event(Evt.Types type, string param)
        {
            Type = type;
            Param = param;
        }
        
        public void Send()
        {
            Core.App.Instance.UiManager.DispatchEvent(this);    
        }

        public static void Register(Action<Evt.Event> action)
        {
            Core.App.Instance.UiManager.RegisterEventListener(action);
        }

        public static void Unregister(Action<Evt.Event> action)
        {
            if (!Core.App.Instance.IsQuitting)
                Core.App.Instance.UiManager.UnregisterEventListener(action);
        }

    }
}
