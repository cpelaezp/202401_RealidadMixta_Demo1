using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public GameObject panel1;

    public void SetShowPanel1()
    {
        Debug.Log("Ingreso al evento");

        if (panel1 != null)
        {
            Debug.Log("Ingreso al panel");
            bool AsActive = panel1.activeSelf;
            panel1.SetActive(!AsActive);
        }
    }
}
