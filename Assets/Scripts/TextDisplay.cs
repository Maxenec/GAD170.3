using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public TextMeshProUGUI myText;

    //Adds text to UI from another script.
    public void AddText(string textToAdd)
    {
        myText.text = textToAdd;
    }
}
