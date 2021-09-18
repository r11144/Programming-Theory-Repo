using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Toggle[] shapeToggles = new Toggle[3];

    private Shape selectedShape;

    [SerializeField]
    private Text infoText;


    public void ToggleShape(Toggle toggle)
    {
        if (toggle.isOn)
        {
            // ABSTRACTION
            DisableActiveToggle(toggle);

            // ABSTRACTION
            selectedShape = GetShapeInfo(toggle);
            DisplayShapeInfo();
        }
        else
        {
            selectedShape = null;
            
            infoText.text = "Select a pet";
        }
    }

    private Shape GetShapeInfo(Toggle toggle)
    {
        if (toggle.CompareTag("Cube"))
        {
            Cube shape = toggle.GetComponent<Cube>();
            return shape;
        }
        else if (toggle.CompareTag("Sphere"))
        {
            Sphere shape = toggle.GetComponent<Sphere>();
            return shape;
        }
        else if (toggle.CompareTag("Capsule"))
        {
            Capsule shape = toggle.GetComponent<Capsule>();
            return shape;
        }
        return null;
    }

    private void DisableActiveToggle(Toggle toggle)
    {
        foreach (var shapeToggle in shapeToggles)
        {
            if (shapeToggle != toggle)
            {
                shapeToggle.isOn = false;
            }
        }
    }

    private void DisplayShapeInfo()
    {
        infoText.text = selectedShape.DisplayInfo() + "\n It's name is " + selectedShape.shapeName;
    }
}
