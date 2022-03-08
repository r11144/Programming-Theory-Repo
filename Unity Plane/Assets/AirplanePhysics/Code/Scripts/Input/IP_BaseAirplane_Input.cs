using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_BaseAirplane_Input : MonoBehaviour
    {
        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;

        protected float stickyThrottle;
        public float StickyThrottle
        {
            get{ return stickyThrottle; }
        }

        [SerializeField]
        public KeyCode brakeKey = KeyCode.Space;
        protected float brake = 0f;

        [SerializeField]
        protected KeyCode cameraKey = KeyCode.C;
        protected bool cameraSwitch = false;

        public int maxFlapIncrements = 2;
        protected int flaps = 0;
        #endregion

        #region Properties

        public float Pitch
        {
            get { return pitch; }
        }

        public float Roll
        {
            get { return roll; }
        }

        public float Yaw
        {
            get { return yaw; }
        }

        public float Throttle
        {
            get { return throttle; }
        }

        public int Flaps
        {
            get { return flaps; }
        }

        public float Brake
        {
            get { return brake; }
        }

        public bool CameraSwitch
        {
            get { return cameraSwitch; }
        }
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start() {}

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput()
        {
            //process main input
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");
            
            
            //process brake input
            brake = Input.GetKey(brakeKey) ? 1f : 0f;

            //process flaps input
            if(Input.GetKeyDown(KeyCode.F))
            {
                flaps += 1;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);

            cameraSwitch = Input.GetKeyDown(cameraKey);
        }
        #endregion

       
    }
}
