using Assets;
using Meta.WitAi.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class CallWS : MonoBehaviour
{
    public enum e_type
    {
        Messages=0,
        Mails=1,
        Tasks=2
    }


    Timer t = new Timer();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicia componente boton 1");

        //GameObject panel1 = GameObject.Find("ScenePanelOne");
        //if(panel1 != null) panel1.SetActive(false);
        GameObject panel2 = GameObject.Find("ScenePanelTwo");
        if (panel2 != null) panel2.SetActive(false);
        GameObject panel3 = GameObject.Find("ScenePanelThree");
        if (panel3 != null) panel3.SetActive(false);
        GameObject panel4 = GameObject.Find("ScenePanelFour");
        if (panel4 != null) panel4.SetActive(false);


        GetMessages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string URL;
    public GameObject panel;
    public string textObject;
    public string textNotificacion;
    public e_type tipo;

    public void GetMessages()
    {
        Debug.Log("dispara consulta");
        StartCoroutine(FetchData());
    }

    public IEnumerator FetchData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            Debug.Log("resultado consulta");
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("resultado consulta" + request.downloadHandler.text);

                switch (tipo)
                {
                    // Message
                    case e_type.Messages:
                        List<cls_Message> listmessages = JsonConvert.DeserializeObject<List<cls_Message>>(request.downloadHandler.text);

                        GameObject testText = GameObject.Find(textObject);
                        if (testText != null)
                        {
                            TextMeshProUGUI thisTextMesh = testText.GetComponent<TextMeshProUGUI>();
                            thisTextMesh.text = "";

                            foreach (cls_Message _item in listmessages)
                            {
                                thisTextMesh.text = thisTextMesh.text + String.Format("\n\n<uppercase><color=\"green\"><<{0}</uppercase> <alpha=#FF>, {1}>>\n\t <color=\"white\">{2}", _item.from, _item.dateSend, _item.message);
                            }
                        }

                        GameObject testNotificacion = GameObject.Find(textNotificacion);
                        if (testNotificacion != null)
                        {
                            TextMeshPro thisTextMeshN = testNotificacion.GetComponent<TextMeshPro>();
                            thisTextMeshN.text = (thisTextMeshN.text.Contains("WhatsApp") ? "WhatsApp \n<color=\"red\">[" + listmessages.Count.ToString() + "]" : "Teams \n <color=\"red\">[" + listmessages.Count.ToString() + "]");

                        }

                        break;

                    // Mails
                    case e_type.Mails: 
                        List<cls_Mail> listmails = JsonConvert.DeserializeObject<List<cls_Mail>>(request.downloadHandler.text);

                        GameObject testText1 = GameObject.Find(textObject);
                        if (testText1 != null)
                        {
                            TextMeshProUGUI thisTextMesh1 = testText1.GetComponent<TextMeshProUGUI>();
                            thisTextMesh1.text = "";

                            foreach (cls_Mail _item in listmails)
                            {
                                thisTextMesh1.text = thisTextMesh1.text + String.Format("\n\n<uppercase><color=\"yellow\"><<{0}</uppercase> <alpha=#FF>, {1}>>\n\t <color=\"white\">{2}", _item.from, _item.dateSend, _item.message);
                                //thisTextMesh1.text = thisTextMesh1.text + String.Format("\n\n<color=\"red\"><<{0}>> <<{1}>>\n\t <color=\"white\">{2}", _item.from, _item.dateSend, _item.message);
                            }
                        }
                         
                        GameObject testNotificacion2 = GameObject.Find(textNotificacion);
                        if (testNotificacion2 != null)
                        {
                            TextMeshPro thisTextMeshN2 = testNotificacion2.GetComponent<TextMeshPro>();
                            thisTextMeshN2.text = "Mails \n<color=\"red\">[" + listmails.Count.ToString() + "]";
                        }

                        break;

                    // Tasks    
                    case e_type.Tasks: 
                        List<cls_Task> listtasks = JsonConvert.DeserializeObject<List<cls_Task>>(request.downloadHandler.text);

                        GameObject testText2 = GameObject.Find(textObject);
                        if (testText2 != null)
                        {
                            TextMeshProUGUI thisTextMesh2 = testText2.GetComponent<TextMeshProUGUI>();
                            thisTextMesh2.text = "";

                            foreach (cls_Task _item in listtasks)
                            {
                                thisTextMesh2.text = thisTextMesh2.text + String.Format("\n\n<mark=#ffffcc><color=\"black\">{0}</mark> <alpha=#FF>, {1}</mark>\n\t <color=\"white\">{2}", _item.name, _item.start, _item.description);
                                //thisTextMesh2.text = thisTextMesh2.text + String.Format("\n\n<color=\"red\"><<{0}>> <<{1}>>\n\t <color=\"white\">{2}", _item.name, _item.start, _item.description);
                            }
                        }

                        GameObject testNotificacion3 = GameObject.Find(textNotificacion);
                        if (testNotificacion3 != null)
                        {
                            TextMeshPro thisTextMeshN3 = testNotificacion3.GetComponent<TextMeshPro>();
                            thisTextMeshN3.text = "Tasks \n<color=\"red\">[" + listtasks.Count.ToString() + "]";
                        }

                        break;
                }
                
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }

}
