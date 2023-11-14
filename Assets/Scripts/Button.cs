using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Renderer renderObject;
    public Material buttonColourChange;

    //Change material of button when function is called.
    public void ButtonPressed()
    {
        renderObject = GetComponent<Renderer>();
        renderObject.material = buttonColourChange;
    }
}
