using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelB1 : MonoBehaviour
{
    GameObject panel;

    public void SetShowPanel() {

        if (panel == null)
        {
            bool AsActive = panel.activeSelf;
            panel.SetActive(!AsActive);
        }
    }
}
