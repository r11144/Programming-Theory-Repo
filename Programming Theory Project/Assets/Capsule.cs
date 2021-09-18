using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Shape
{
    private void Start()
    {
        shapeName = SetName(MainManager.Instance.capsuleName);

    }

    // POLYMORPHISM
    public override string DisplayInfo()
    {
        return "This is a cat.";
    }
}
