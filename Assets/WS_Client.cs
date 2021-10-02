using UnityEngine;
using WebSocketSharp;
public class WS_Client : MonoBehaviour
{
    WebSocket ws;
    public GameObject cube;
  
    private void Start()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var BallRenderer = cube.GetComponent<Renderer>();
     //   BallRenderer.material.SetColor("_Color", Color.green);
        cube.transform.position = new Vector3((float)6.27, (float)1.64, (float)5.7);

        ws = new WebSocket("ws://192.168.43.76:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            //string json = JsonUtility.ToJson(e);
            // string json = JsonUtility.ToJson(e, true);
            ws.Send((e.Data));
            Debug.Log("Tsdshe temperature is " + e.Data);

            // var temp = int.Parse(e.Data);


            // attempt to parse the value using the TryParse functionality of the integer type
           int i = System.Convert.ToInt32(e.Data);

            Debug.Log("Look here: " + i);//9001

            Debug.Log("testing");
            if (i == i)
            {
                var BallRenderer = cube.GetComponent<Renderer>();
                Debug.Log("Did we get gere? ");
                BallRenderer.material.SetColor("_Color", Color.green);
                Debug.Log("Did we get gere? ");
            }



        };
    }
    
    private void Update()
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
        /*if (Input.GetButton("Button.One"));
        {
            ws.Send("4");
        }*/ //Doesnt work
    }

}