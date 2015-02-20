using System;
using UnityEngine;


namespace Ui 
{
    public class UiManager : Core.MonoBehaviourGod
    {

        public class Environment
        {
            public Canvas Canvas;
        }
        
        // Reference to UiFactory
        public IUIFactory Factory { get; private set; }

        public WindowManager WindowManager { get; private set; }

        public Environment Env { get; set;  }

        public Evt.IEventDispatcher EventDispatcher { get; private set; }


        public void Init(IUIFactory factory)
        {
            EventDispatcher = new Evt.EventDispatcher();

            Env = new Environment();

            // Find canvas
            SetEnvironment();

            // Assign factory
            Factory = factory;

            // Create WindowManager
            WindowManager = WindowManager.CreateInstance();
            WindowManager.Init(this);
            WindowManager.transform.SetParent(transform);

            Animator = GetComponent<Animator>();
        }

        private Animator Animator { get; set; }

        private static UiManager instance;

      
        public void LoadScene(string scene)
        {
            Animator.SetTrigger(scene);

            Application.LoadLevel(scene);   
        }

        public static UiManager CreateInstance()
        {
            return Core.App.Instance.Res.Instantiate<UiManager>("Prefabs/Ui/UiManager");
        }

        private void SetEnvironment()
        {
            Env.Canvas = GameObject.FindObjectOfType<Canvas>();
        }
    }
}
