using System;
using System.Collections.Generic;
using UnityEngine;


namespace Ui
{

    public class WindowManager : Core.MonoBehaviourGod
    {
        // Currently opened windows
        private List<Window> Windows { get; set; }

        // Windows being closed
        private List<Window> ClosingWindows { get; set; }
        
        // Windows waiting to be opened
        private List<Window> WindowsToOpen { get; set; }

        // Reference to UIManager
        private UiManager UiManager { get; set; }


        // Creates instance
        public static WindowManager CreateInstance()
        {
            var go = (Instantiate(Resources.Load<GameObject>("Prefabs/Ui/WindowManager")) as GameObject);
            return go.GetComponent<WindowManager>();
        }


        public void Init(UiManager uiManager)
        {
            base.Init();

            UiManager = uiManager;

            Windows = new List<Window>();
            ClosingWindows = new List<Window>();
            WindowsToOpen = new List<Window>();
        }
     
        // Open Window by name and param
        public Window OpenWindow(string name, object param = null)
        {
            // Use factory to create window object
            var window = UiManager.Factory.Create<Window>(name);

            // Place window under canvas hierarchy
            window.gameObject.transform.SetParent(UiManager.Env.Canvas.transform);

            // register actions here
            window.OpenFinished += this.OnWindowOpen;
            window.CloseFinished += this.OnWindowClosed;

            window.Init(param);

            // add to list of windows
            Windows.Add(window);

            // if any window is being closed, wait for finish
            if (ClosingWindows.Count > 0)
            {
                WindowsToOpen.Add(window);
            }
            // open now
            else
            {
                window.Open();
            }

            return window;
        }

        // Close Window by name
        public void CloseWindow(string name)
        {
            if (IsOpen(name))
            {
                int index = Windows.FindIndex(x => x.Name == name);

                var win = Windows[index];

                Windows.RemoveAt(index);

                win.Close();

                ClosingWindows.Add(win);
            }
        }

        
        public bool IsOpen(string name)
        {
            return Windows.Find(x => x.Name == name) != null;
        }

        private void OnWindowClosed(Window window)
        {
            ClosingWindows.Remove(window);

            Destroy(window.gameObject);

            if (WindowsToOpen.Count > 0)
            {
                WindowsToOpen[0].Open();
                WindowsToOpen.RemoveAt(0);
            }
        }

        private void OnWindowOpen(Window window)
        {
            if (WindowsToOpen.Count > 0)
            {
                WindowsToOpen[0].Open();
                WindowsToOpen.RemoveAt(0);
            }
        }

        private void OnLevelWasLoaded(int level)
        {
            Windows.Clear();
            ClosingWindows.Clear();
            WindowsToOpen.Clear();
        }
    }
}
