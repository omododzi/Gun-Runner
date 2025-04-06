using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private MAgazine magazine;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(OnButtonClick);
        magazine = GetComponent<MAgazine>();

    }

    public void OnButtonClick()
    {
        move.restarting = true;
        move.canMove = false;
        magazine.Inmagaz();
    }
}
