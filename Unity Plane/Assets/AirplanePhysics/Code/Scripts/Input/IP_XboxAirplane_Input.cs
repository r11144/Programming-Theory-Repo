using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_XboxAirplane_Input : IP_BaseAirplane_Input
    {
        public float throttleSpeed = 0.1f;

        protected override void HandleInput()
        {
            //process main input
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");
            StickyThrottleControl();

            //process brake input
            brake = Input.GetKey(brakeKey) ? 1f : 0f;

            //process flaps input
            if (Input.GetKeyDown(KeyCode.F))
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

        void StickyThrottleControl()
        {
            stickyThrottle = stickyThrottle + (throttle * throttleSpeed * Time.deltaTime);
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
           // Debug.Log(stickyThrottle);
        }
    }
}
