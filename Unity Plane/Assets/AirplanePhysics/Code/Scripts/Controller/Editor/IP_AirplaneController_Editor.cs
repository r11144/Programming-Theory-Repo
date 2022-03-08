using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace IndiePixel
{
    [CustomEditor(typeof(IP_Airplane_Controller))]
    public class IP_AirplaneController_Editor : Editor
    {
        #region Variables
        private IP_Airplane_Controller targetController;
        #endregion

        #region Builtin Methods
        private void OnEnable()
        {
            targetController = (IP_Airplane_Controller)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(15);
            if(GUILayout.Button("Get Airplane Components", GUILayout.Height(35)))
            {
                targetController.engines.Clear();
                targetController.engines = FindAllEngines().ToList<IP_Airplane_Engine>();

                targetController.wheels.Clear();
                targetController.wheels = FindAllWheels().ToList<IP_Airplane_Wheel>();

                targetController.contolSurfaces.Clear();
                targetController.contolSurfaces = FindAllControlSurfaces().ToList<IP_Airplane_ContolSurfaces>();
            }
            

            if(GUILayout.Button("Create Airplane Preset", GUILayout.Height(35)))
            {
                string filePath = EditorUtility.SaveFilePanel("Save Airplane Preset", "Assets", "New_Airplane_Preset", "asset");
                SaveAirplanePreset(filePath);
            }

            GUILayout.Space(15);

        }
        #endregion

        #region Custom Methods
        IP_Airplane_Engine[] FindAllEngines()
        {
            IP_Airplane_Engine[] engines = new IP_Airplane_Engine[0];
            if (targetController)
            {
                engines = targetController.transform.GetComponentsInChildren<IP_Airplane_Engine>(true);
            }
            return engines;
        }

        IP_Airplane_Wheel[] FindAllWheels()
        {
            IP_Airplane_Wheel[] wheels = new IP_Airplane_Wheel[0];
            if (targetController)
            {
                wheels = targetController.transform.GetComponentsInChildren<IP_Airplane_Wheel>(true);
            }
            return wheels;
        }

        IP_Airplane_ContolSurfaces[] FindAllControlSurfaces()
        {
            IP_Airplane_ContolSurfaces[] controlSurfaces = new IP_Airplane_ContolSurfaces[0];
            if (targetController)
            {
                controlSurfaces = targetController.transform.GetComponentsInChildren<IP_Airplane_ContolSurfaces>(true);
            }
            return controlSurfaces;
        }

        void SaveAirplanePreset(string aPath)
        {
            if(targetController && !string.IsNullOrEmpty(aPath))
            {
                string appPath = Application.dataPath;

                string finalPath = "Assets" + aPath.Substring(appPath.Length);

                //Create new Preset
                IP_Airplane_Preset newPreset = ScriptableObject.CreateInstance<IP_Airplane_Preset>();
                newPreset.airplaneWeight = targetController.airplaneWeight;

                if (targetController.centerOfGravity)
                {
                    newPreset.cogPosition = targetController.centerOfGravity.localPosition;
                }

                if (targetController.characteristics)
                {
                    newPreset.dragFactor = targetController.characteristics.dragFactor;
                    newPreset.maxMPH = targetController.characteristics.maxMPH;
                    newPreset.rbLerpSpeed = targetController.characteristics.rbLerpSpeed;
                    newPreset.maxLiftPower = targetController.characteristics.maxLiftPower;
                    newPreset.flapDragFactor = targetController.characteristics.flapDragFactor;
                    newPreset.pitchSpeed = targetController.characteristics.pitchSpeed;
                    newPreset.rollSpeed = targetController.characteristics.rollSpeed;
                    newPreset.yawSpeed = targetController.characteristics.yawSpeed;
                    newPreset.liftCurve = targetController.characteristics.liftCurve;
                }

                //Create final Preset
                AssetDatabase.CreateAsset(newPreset, finalPath);
                
            }
        }
        #endregion
    }
}
