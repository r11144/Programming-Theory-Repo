using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    private void Start()
    {
        shapeName = SetName(MainManager.Instance.cubeName);

    }

    // POLYMORPHISM
    public override string DisplayInfo()
    {
        return "This is a cat.";
    }
}
