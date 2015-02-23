using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Ui
{
    public class TestWindow : Window
    {

        [SerializeField]
        Button btn;

        public override void Init(object param)
        {
            base.Init(param);

            var acontainer = btn.gameObject.AddComponent<Ui.Action.Container>();

            var action = acontainer.AddAction<Ui.Action.ActionEnabler>();
            action.Set(Evt.Types.WindowOpenFinished, Name, 2, true,  () =>
            {
               Core.Dbg.Log("Test", Core.Dbg.MessageType.Info);
            });
            action.Enable = false;
            action.GameObjects.Add(btn.gameObject);
        }
    }

}