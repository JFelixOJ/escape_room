using UnityEngine;
using WebSocketSharp;
public class WS_Client : MonoBehaviour
{
    WebSocket ws;
    public GameObject ball;
    public Renderer ballRenderer;
    public int x;
    public int temp;
    public Color newColor;

    private void Start()
    {
        newColor = new Color32(0, 107, 255, 0);

        ballRenderer = ball.GetComponent<Renderer>();

        x = 0; //For fake input
        temp = 0; //For fake input

        ws = new WebSocket("ws://192.168.43.76:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            int fakeTempToInt = System.Convert.ToInt32(e.Data);
            Debug.Log("Arrived Temp: " + fakeTempToInt);//9001
            temp = fakeTempToInt;
        };
    }

    private void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (x == 1000)
        {
            ws.Send("1".ToString());
            x = 0;    
        }
        x += 1;
       this.SetColor(temp);

    }

    private void SetColor(int temperature)
    {
        switch (temp)
        {
            case 10:
                newColor = new Color32(51, 107, 255, 0);
                break;
            case 11:
                newColor = new Color32(60, 54, 255, 0);
                break;
            case 12:
                newColor = new Color32(70, 51, 255, 0);
                break;
            case 13:
                newColor = new Color32(80, 51, 255, 0);
                break;
            case 14:
                newColor = new Color32(90, 51, 255, 0);
                break;
            case 15:
                newColor = new Color32(100, 51, 255, 0);
                break;
            case 16:
                newColor = new Color32(110, 107, 255, 0);
                break;
            case 17:
                newColor = new Color32(0, 107, 255, 0);
                break;
            case 18:
                newColor = new Color32(0, 107, 255, 0);
                break;
            case 19:
                newColor = new Color32(0, 50, 50, 0);
                break;
            case 20:
                newColor = new Color32(0, 50, 50, 0);
                break;
            case 21:
                newColor = new Color32(50, 50, 50, 0);
                break;
            case 22:
                newColor = new Color32(100, 50, 50, 0);
                break;
            case 23:
                newColor = new Color32(150, 50, 50, 0);
                break;
            case 24:
                newColor = new Color32(200, 50, 50, 0);
                break;
            case 25:
                newColor = new Color32(250, 50, 50, 0);
                break;
            case 26:
                newColor = new Color32(170, 107, 110, 0);
                break;
            case 27:
                newColor = new Color32(200, 107, 95, 0);
                break;
            case 28:
                newColor = new Color32(230, 107, 80, 0);
                break;
            case 29:
                newColor = new Color32(255, 107, 65, 0);
                break;
            case 30:
                newColor = new Color32(255, 107, 0, 0);
                break;
            default:
                break;
        }

        foreach (Material mat in ballRenderer.materials)
        {
            mat.color = newColor;
        }
    }
}