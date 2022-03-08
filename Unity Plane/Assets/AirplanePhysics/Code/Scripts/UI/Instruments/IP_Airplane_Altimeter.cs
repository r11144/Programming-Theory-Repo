using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Airplane_Altimeter : MonoBehaviour, IAirplaneUI
    {
        #region Variables
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {

        }
        #endregion

        #region Interface Methods
        public void HandleAirplaneUI()
        {
            Debug.Log("Updating the Altimeter");
        }
        #endregion
    }
}