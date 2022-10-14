using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionDisplay : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI sliderValueDisplay;
        

    // Update is called once per frame
    void Update()
    {
        sliderValueDisplay.text = "every " + (slider.value).ToString() + " sec";
    }
}
