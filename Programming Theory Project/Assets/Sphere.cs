using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    private void Start()
    {
        shapeName = SetName(MainManager.Instance.sphereName);
       
    }

    // POLYMORPHISM
    public override string DisplayInfo()
    {
        return "This is a cat.";
    }
}
