using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndiePixel
{
    public static class IP_Airplane_Menus
    {
       [MenuItem("Airplane Tools/Create New Airplane")]
       public static void CreateNewAirplane()
        {
            IP_AirplaneSetup_Window.LaunchSetupWindow();
        }
    }
}
