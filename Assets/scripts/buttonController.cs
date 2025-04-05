using UnityEngine;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{
    public static GameObject button1;
    public static GameObject button2;
    public static GameObject button3;
    public static GameObject button4;

    void Start()
    {
        button1 = GameObject.FindGameObjectWithTag("Baff1");
        button2 = GameObject.FindGameObjectWithTag("Baff2");
        button3 = GameObject.FindGameObjectWithTag("Baff3");
        button4 = GameObject.FindGameObjectWithTag("Start");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        gameObject.SetActive(false);
        move.canMove = true;
    }

    public static void Magazine()
    {
        move.canMove = false;
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
    }
}
