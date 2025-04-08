using UnityEngine;

public class MAgazine : MonoBehaviour
{
    public GameObject start;
    public GameObject baff1;
    public GameObject baff2;
    public GameObject baff3;
    public static bool inmagazine = true;

    public  void Inmagaz()
    {
        inmagazine = true;
        start.SetActive(true);
        baff1.SetActive(true);
        baff2.SetActive(true);
        baff3.SetActive(true);
    }
}
