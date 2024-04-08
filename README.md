<h1>REALIDAD MIXTA - DEMO 1</h1>
<h2>WORK TOOLS</h2>
<h3>Descripción</h3>
<p>Proyecto de realidad mixta desarrollado en Unity Hub 3.7.0 Editor 2022.1.20f1 para MetaQuest2. Este proyecto se enfoca en mostrar utilidades para el trabajo diario, en un ambiente de un desarrollador se mostrará diferentes medios de comunicación que se utilizan para ambientes colaborativos. &nbsp;&nbsp;</p>
<figure class="table" style="width:100%;">
    <table class="ck-table-resized">
        <colgroup>
            <col style="width:48.36%;">
            <col style="width:51.64%;">
        </colgroup>
        <tbody>
            <tr>
                <td>
                    <img src="Images/Image1.png">
                </td>
                <td>
                    <img src="Images/Image2.png">
                </td>
            </tr>
        </tbody>
    </table>
</figure>
<h3>Videos</h3>
<figure class="table" style="width:94.13%;">
    <table class="ck-table-resized">
        <colgroup>
            <col style="width:25.21%;">
            <col style="width:74.79%;">
        </colgroup>
        <tbody>
            <tr>
                <td>Explicación ApiRest</td>
                <td>
                    <figure class="media">
                        <oembed url="https://youtu.be/CL51ijgZsZI?si=si9ZEDXKj8Juy6Cq"></oembed>
                    </figure>
                </td>
            </tr>
            <tr>
                <td>Proyecto Unity</td>
                <td>
                    <figure class="media">
                        <oembed url="https://youtu.be/ntC6jkQBxnQ"></oembed>
                    </figure>
                </td>
            </tr>
            <tr>
                <td>Simulación en MetaQuest 2</td>
                <td>
                    <figure class="media">
                        <oembed url="https://youtu.be/BGhyILvoMmo"></oembed>
                    </figure>
                </td>
            </tr>
            <tr>
                <td>Video Consolidado</td>
                <td>
                    <figure class="media">
                        <oembed url="https://youtu.be/llDckHwLm5M"></oembed>
                    </figure>
                </td>
            </tr>
        </tbody>
    </table>
</figure>
<h3>Componenes</h3>
<h4>Api_Task</h4>
<p>Proyecto en Netcore 7 y c#, se creó para que desde unity se pueda consultar consulta cada uno de los origen de datos.</p>
<figure class="table">
    <table>
        <tbody>
            <tr>
                <td>MAILS</td>
                <td>Lista de mails del bubon corporativo</td>
            </tr>
            <tr>
                <td>MESSAGES</td>
                <td>Lista de mensajes de Whatsapp y Teams</td>
            </tr>
            <tr>
                <td>TASKS</td>
                <td>Lista de tareas asignadas para el trabajo diario</td>
            </tr>
        </tbody>
    </table>
</figure>
<p>&nbsp;</p>
<img src="Images/Image3.png">
<h4>WorlToolsM</h4>
<p>Proyecto en unity que consume un api de información y la muestra al desarrollador en realidad mixta</p>
<img src="Images/Image4.png">

<h5>Configuración</h5>
<img src="Images/Image5.png">
<h5>Plugins</h5>
<img src="Images/Image6.png">
<h5>Desarrollo</h5>
<h6>Estructura del proyecto</h6>
<img src="Images/Image7.png">
<h6>Modelo</h6>
<p>Se crea un modelo de datos para devolver cada uno de los tipos de mensajes</p>
<pre><code class="language-cs">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class cls_Task
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }

    }

    public class Listcls_Message
    {
        public List&lt;cls_Message&gt; Tasks;
    }

    public class cls_Message
    {
        public int id { get; set; }
        public string from { get; set; }
        public int type { get; set; }
        public DateTime dateSend { get; set; }
        public DateTime dateRead { get; set; }
        public string message { get; set; }
        public string status { get; set; }

    }

    public class cls_Mail
    {
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime dateSend { get; set; }
        public DateTime dateRead { get; set; }
        public string message { get; set; }
        public string status { get; set; }

    }
}
</code></pre>
<h6>CallWS</h6>
<p>Esta Clase permite llamar al ApiRest y devolver todos los mensajes asignados a un usuario.</p>
<pre><code class="language-cs">using Assets;
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
                        List&lt;cls_Message&gt; listmessages = JsonConvert.DeserializeObject&lt;List&lt;cls_Message&gt;&gt;(request.downloadHandler.text);

                        GameObject testText = GameObject.Find(textObject);
                        if (testText != null)
                        {
                            TextMeshProUGUI thisTextMesh = testText.GetComponent&lt;TextMeshProUGUI&gt;();
                            thisTextMesh.text = "";

                            foreach (cls_Message _item in listmessages)
                            {
                                thisTextMesh.text = thisTextMesh.text + String.Format("\n\n&lt;uppercase&gt;&lt;color=\"green\"&gt;&lt;&lt;{0}&lt;/uppercase&gt; &lt;alpha=#FF&gt;, {1}&gt;&gt;\n\t &lt;color=\"white\"&gt;{2}", _item.from, _item.dateSend, _item.message);
                            }
                        }

                        GameObject testNotificacion = GameObject.Find(textNotificacion);
                        if (testNotificacion != null)
                        {
                            TextMeshPro thisTextMeshN = testNotificacion.GetComponent&lt;TextMeshPro&gt;();
                            thisTextMeshN.text = (thisTextMeshN.text.Contains("WhatsApp") ? "WhatsApp \n&lt;color=\"red\"&gt;[" + listmessages.Count.ToString() + "]" : "Teams \n &lt;color=\"red\"&gt;[" + listmessages.Count.ToString() + "]");

                        }

                        break;

                    // Mails
                    case e_type.Mails: 
                        List&lt;cls_Mail&gt; listmails = JsonConvert.DeserializeObject&lt;List&lt;cls_Mail&gt;&gt;(request.downloadHandler.text);

                        GameObject testText1 = GameObject.Find(textObject);
                        if (testText1 != null)
                        {
                            TextMeshProUGUI thisTextMesh1 = testText1.GetComponent&lt;TextMeshProUGUI&gt;();
                            thisTextMesh1.text = "";

                            foreach (cls_Mail _item in listmails)
                            {
                                thisTextMesh1.text = thisTextMesh1.text + String.Format("\n\n&lt;uppercase&gt;&lt;color=\"yellow\"&gt;&lt;&lt;{0}&lt;/uppercase&gt; &lt;alpha=#FF&gt;, {1}&gt;&gt;\n\t &lt;color=\"white\"&gt;{2}", _item.from, _item.dateSend, _item.message);
                                //thisTextMesh1.text = thisTextMesh1.text + String.Format("\n\n&lt;color=\"red\"&gt;&lt;&lt;{0}&gt;&gt; &lt;&lt;{1}&gt;&gt;\n\t &lt;color=\"white\"&gt;{2}", _item.from, _item.dateSend, _item.message);
                            }
                        }
                         
                        GameObject testNotificacion2 = GameObject.Find(textNotificacion);
                        if (testNotificacion2 != null)
                        {
                            TextMeshPro thisTextMeshN2 = testNotificacion2.GetComponent&lt;TextMeshPro&gt;();
                            thisTextMeshN2.text = "Mails \n&lt;color=\"red\"&gt;[" + listmails.Count.ToString() + "]";
                        }

                        break;

                    // Tasks    
                    case e_type.Tasks: 
                        List&lt;cls_Task&gt; listtasks = JsonConvert.DeserializeObject&lt;List&lt;cls_Task&gt;&gt;(request.downloadHandler.text);

                        GameObject testText2 = GameObject.Find(textObject);
                        if (testText2 != null)
                        {
                            TextMeshProUGUI thisTextMesh2 = testText2.GetComponent&lt;TextMeshProUGUI&gt;();
                            thisTextMesh2.text = "";

                            foreach (cls_Task _item in listtasks)
                            {
                                thisTextMesh2.text = thisTextMesh2.text + String.Format("\n\n&lt;mark=#ffffcc&gt;&lt;color=\"black\"&gt;{0}&lt;/mark&gt; &lt;alpha=#FF&gt;, {1}&lt;/mark&gt;\n\t &lt;color=\"white\"&gt;{2}", _item.name, _item.start, _item.description);
                                //thisTextMesh2.text = thisTextMesh2.text + String.Format("\n\n&lt;color=\"red\"&gt;&lt;&lt;{0}&gt;&gt; &lt;&lt;{1}&gt;&gt;\n\t &lt;color=\"white\"&gt;{2}", _item.name, _item.start, _item.description);
                            }
                        }

                        GameObject testNotificacion3 = GameObject.Find(textNotificacion);
                        if (testNotificacion3 != null)
                        {
                            TextMeshPro thisTextMeshN3 = testNotificacion3.GetComponent&lt;TextMeshPro&gt;();
                            thisTextMeshN3.text = "Tasks \n&lt;color=\"red\"&gt;[" + listtasks.Count.ToString() + "]";
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
</code></pre>
<h6>&nbsp;Configuración</h6>
<p>Para cada boton que muestra la información se creó un script de Unity, en el cual se debe configurar los siguientes datos.</p>
<img src="Images/Image8.png">
<p>&nbsp;</p>
<figure class="table">
    <table>
        <tbody>
            <tr>
                <td>Call WS</td>
                <td>URL</td>
                <td>
                    <p>Url del api, para desarrollo se configura la ip de la máquina de desarrollo</p>
                    <p>http://192.168.0.137:32771/api/Messages</p>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Panel</td>
                <td>Nombre del Panel donde se mostrara la información</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>TextObject</td>
                <td>Texto donde se mostraran los mensajes.&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>TextNotificacion</td>
                <td>Texto donde se mostraran los mensajes.&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Tipo</td>
                <td>Tipo de información a mostrar (MESSAGES, MAILS, TASKS)</td>
            </tr>
            <tr>
                <td>ShowPanel</td>
                <td>Panel1</td>
                <td>Panel que se mostrara o se ocultara con el event de seleccionar el boton.</td>
            </tr>
        </tbody>
    </table>
</figure>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
