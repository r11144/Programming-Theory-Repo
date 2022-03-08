using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Airplane_Propeller : MonoBehaviour
    {
        #region Variables
        [Header("Propeller Properties")]
        public float minRotationRPM = 30f;
        public float minQuadRPMs = 300f;
        public float minTextureSwap = 600f;
        public GameObject mainProp;
        public GameObject bluredProp;

        [Header("Material Properties")]
        public Material blurredPropMat;
        public Texture2D blurLevel1;
        public Texture2D blurLevel2;
        #endregion

        #region Builtin Methods
        void Start()
        {
            if (mainProp && bluredProp)
            {
                HandleSwapping(0f);
            }
        }
        #endregion

        #region Custom Methods
        public void HandlePropeller(float currentRPM)
        {
            float dps = (((currentRPM * 360f) / 60f) + minRotationRPM) * Time.deltaTime;
            dps = Mathf.Clamp(dps, 0f, minRotationRPM);

            transform.Rotate(Vector3.forward, dps);

            if (mainProp && bluredProp)
            {
                HandleSwapping(currentRPM);
            }
        }

        void HandleSwapping(float currentRPM)
        {
            if (currentRPM > minQuadRPMs)
            {
                bluredProp.gameObject.SetActive(true);
                mainProp.gameObject.SetActive(false);

                if (blurredPropMat && blurLevel1 && blurLevel2)
                {
                    if (currentRPM > minTextureSwap)
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel2);
                    }
                    else
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel1);
                    }
                } 
            }
            else
            {
                bluredProp.gameObject.SetActive(false);
                mainProp.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}