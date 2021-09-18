using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    // ENCAPSULATION
    private string shape_name = "";
    public string shapeName
    {
        get
        {
            return shape_name;
        }
        protected set
        {
            if (value.Length > 10)
            {
                Debug.LogError("Your pet name is too long");
            }
            else
            {
                shape_name = value;
            }
        }
    }


    protected string SetName(string name)
    {
        return name;
    }

    // POLYMORPHISM
    public abstract string DisplayInfo();
}
