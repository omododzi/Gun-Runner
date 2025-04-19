using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private MAgazine magazine = new MAgazine();

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(OnButtonClick);
        magazine = GetComponent<MAgazine>();

    }

    public void OnButtonClick()
    {
        MAgazine.inmagazine = true;
        move.restarting = true;
        move.canMove = false;
        magazine.Inmagaz();
    }
}
