using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class OptionsScreen : MonoBehaviour
{

    public Toggle fullScreenTog, vsyncTog;

    public TMP_Dropdown resolution;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        vsyncTog.isOn = QualitySettings.vSyncCount != 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is to make the changes visible and reload
    public void ApplyGraphics()
    {
        var res = resolution.captionText.text;
        var pxls = res.Split('x');
        var x = Convert.ToInt32(pxls[0]);
        var y = Convert.ToInt32(pxls[1]);
        Screen.SetResolution(x, y, fullScreenTog.isOn);
        Screen.fullScreen = fullScreenTog.isOn;
        QualitySettings.vSyncCount = vsyncTog.isOn ? 1 : 0;
    }
}
