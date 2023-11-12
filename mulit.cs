using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class mulit : MonoBehaviour
{

    public String action;
    public String arrow_x;
    public String arrow_y;

    public String std_num;
    private String[] arr;
    public TMP_InputField std;
    public TMP_InputField x_asix;
    public TMP_InputField y_asix;
    public TMP_Dropdown actions;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(update_action());
    }
    void Update(){
        Debug.Log(actions.options[actions.value].text);
        action = actions.options[actions.value].text;
        arrow_x = x_asix.text;
        arrow_y = y_asix.text;
        std_num = std.text;
    }

    
    IEnumerator update_action(){
        
            yield return new WaitForSeconds(2);
            StartCoroutine(connect());
            StartCoroutine(update_action());
        }

    IEnumerator connect(){
        WWWForm form = new WWWForm();
            form.AddField("action", action);
            form.AddField("ax", arrow_x);
            form.AddField("ay", arrow_y);
            form.AddField("nums", std_num);

            using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.24/multi/user.php", form)) {
                yield return www.SendWebRequest();

                if(www.isNetworkError || www.isHttpError) {
                    Debug.Log(www.error);
                    
                }
                else{
                    Debug.Log(www.downloadHandler.text);
                    if(action == "getcon"){
                        arr = www.downloadHandler.text.Split(",");
                        Debug.Log(arr);
                        
                        walk(Convert.ToInt32(arr[0]),Convert.ToInt32(arr[1]));
                    }
                    
                }
            }
        }
    
    void walk(int x, int y){
        transform.Translate(x, y, Time.deltaTime);
    }

    public void refresh(){
        StartCoroutine(connect());
    }
}
