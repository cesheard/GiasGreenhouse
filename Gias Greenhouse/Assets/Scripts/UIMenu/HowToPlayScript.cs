using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public GameObject hTP_Page1;
    public GameObject hTP_Page2;

    private void Start()
    {
        GoToPage1();

    } // End of Start()

    public void GoToPage2()
    {
        hTP_Page1.SetActive(false);
        hTP_Page2.SetActive(true);

    } // End of GoToPage2()
    public void GoToPage1()
    {
        hTP_Page1.SetActive(true);
        hTP_Page2.SetActive(false);

    } // End of GoToPage1()
}
