using UnityEngine;
using WebSocketSharp;
public class WS_Client : MonoBehaviour
{
    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            //string json = JsonUtility.ToJson(e);
            // string json = JsonUtility.ToJson(e, true);

            Debug.Log("This is the object " + e.Data);


        };
    }private void Update()
    {
        if(ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("1");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ws.Send("2");
        }
    }

}