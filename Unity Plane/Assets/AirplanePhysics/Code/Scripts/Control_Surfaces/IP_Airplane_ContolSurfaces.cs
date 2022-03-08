using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public enum ControlSurfaceType
    {
        Rudder,
        Elevator,
        Flap,
        Aileron
    }
    public class IP_Airplane_ContolSurfaces : MonoBehaviour
    {
        #region Variables
        [Header("Control Surfaces Properties")]
        public ControlSurfaceType type = ControlSurfaceType.Rudder;
        public float maxAngle = 30f;
        public Vector3 axis = Vector3.right;
        public Transform controlSurfaceGraphics;
        public float smoothSpeed = 2f;

        private float wantedAngle;
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            if (controlSurfaceGraphics)
            {
                Vector3 finalAngleAxis = axis * wantedAngle;
                controlSurfaceGraphics.localRotation = Quaternion.Slerp(controlSurfaceGraphics.localRotation, Quaternion.Euler(finalAngleAxis), Time.deltaTime * smoothSpeed);
            }
        }
        #endregion

        #region Custom Methods
        public void HandleControlSurfaces(IP_BaseAirplane_Input input)
        {
            float inputValue = 0f;
            switch(type)
            {
                case ControlSurfaceType.Rudder:
                    inputValue = input.Yaw;
                    break;

                case ControlSurfaceType.Elevator:
                    inputValue = input.Pitch;
                    break;

                case ControlSurfaceType.Flap:
                    inputValue = input.Flaps;
                    break;

                case ControlSurfaceType.Aileron:
                    inputValue = input.Roll;
                    break;

                default:
                    break;
            }

            wantedAngle = maxAngle * inputValue;
        }
        #endregion
    }
}