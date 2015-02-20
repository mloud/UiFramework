using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ui.Action
{
    [System.Serializable]
    public class ActionAnim : ActionBase
    {
        public string ClipName;

        public Animation Animation;

        protected override void OnRun()
        {
            Animation.gameObject.SetActive(true);
            Animation.Play();
            Core.Dbg.Log("ActionAnim.Run()");
        }
    }
}
