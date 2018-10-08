using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ServerConnect : MonoBehaviour {


    string cAdrTemp = "http://130.240.134.126:1026/v1/queryContext";
    public static string txt = "";

    public void Start()
    {
        //sendSecondToken();
        callToken();
    }


    private void callToken()
    {
        try
        {
            //string postData = "{\"entities\":[{\"type\":\"Room\",\"isPattern\":\"false\",\"id\":\"H\"}]}";
            string postData = "{\"entities\":[{\"id\":\"0004a30b0022a677\",\"type\":\"LORA_Sensor\",\"isPattern\":\"false\"}]}";
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add("Content-Type", "application/json");
            byte[] pData = Encoding.UTF8.GetBytes(postData.ToCharArray());
            WWW api = new WWW(cAdrTemp, pData, headers);
            StartCoroutine(this.call(api));
        }
        catch (UnityException ex)
        {
            Debug.Log(ex.Message);
        }
    }


    IEnumerator call(WWW www)
    {
        yield return www;


        
        if (string.IsNullOrEmpty(www.error))
        {
            txt = www.text;  //text of success
        }
        else
        {
            txt = www.error;  //error
        }
        //Debug.Log(txt);
    }
}
