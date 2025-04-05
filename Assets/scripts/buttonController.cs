using UnityEngine;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{
    // 1. Делаем поля приватными (но сериализуемыми)
    [SerializeField] private GameObject Buff1;
    [SerializeField] private GameObject Buff2;
    [SerializeField] private GameObject Buff3;
    [SerializeField] private GameObject start;

    // 2. Убираем static у Magazine
    public void Magazine() 
    {
        move.canMove = false;
        Buff1.SetActive(true);
        Buff2.SetActive(true);
        Buff3.SetActive(true);
        start.SetActive(true);
    }

    // 3. Исправляем OnrestartClick → OnRestartClick
    public void OnRestartClick() 
    {
        move.restarting = true;
        move.canMove = false;
    }

    private void Start()
    {
        // 4. Ищем объекты, если не заданы в Inspector
        if (Buff1 == null) Buff1 = GameObject.FindGameObjectWithTag("Baff1");
        if (Buff2 == null) Buff2 = GameObject.FindGameObjectWithTag("Baff2");
        if (Buff3 == null) Buff3 = GameObject.FindGameObjectWithTag("Baff3");
        if (start == null) start = GameObject.FindGameObjectWithTag("Start");

        // 5. Назначаем обработчик кнопки
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        Buff1.SetActive(false);
        Buff2.SetActive(false);
        Buff3.SetActive(false);
        start.SetActive(false);
        move.canMove = true;
    }
}
