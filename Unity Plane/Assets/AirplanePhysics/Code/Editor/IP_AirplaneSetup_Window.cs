using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndiePixel
{
    public class IP_AirplaneSetup_Window : EditorWindow
    {
        #region Variables
        private string wantedName;
        #endregion

        #region Buildin Methods
        public static void LaunchSetupWindow()
        {
             IP_AirplaneSetup_Window.GetWindow(typeof(IP_AirplaneSetup_Window), true, "Airplane Setup").Show();
        }

        void OnGUI()
        {
            wantedName = EditorGUILayout.TextField("Airplane Name", wantedName);

            if(GUILayout.Button("Create New Airplane"))
            {
                IP_Airplane_Tools.BuildDefaultAirplane(wantedName);

                IP_AirplaneSetup_Window.GetWindow<IP_AirplaneSetup_Window>().Close();
            }
        }
        #endregion
    }
}
