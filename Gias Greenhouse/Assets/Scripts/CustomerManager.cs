using System.Collections;
using UnityEngine;
using TMPro;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] public GameManager gameManger;

    public Customer[] listOfCustomers;
    public string[] potentialCustomerNames;
    public int currentCustomer = -1;

    public TMP_Text customerText;
    public TMP_Text customerTomatoText;
    public TMP_Text customerPotatoText;
    public TMP_Text customerCarrotText;

    [SerializeField] public CanvasGroup feedbackCanvasGroup;

    private void Awake()
    {
        //gameManger = FindObjectOfType<GameManager>();

        foreach(Customer customer in listOfCustomers)
        {
            customer.customerName = potentialCustomerNames[Random.Range(0, potentialCustomerNames.Length)];
            customer.numWantedTomatoes = Random.Range(0, 6);
            customer.numWantedPotatoes = Random.Range(0, 6);
            customer.numWantedCarrots = Random.Range(0, 6);
        }

        currentCustomer = 0;
        customerText.text = listOfCustomers[0].customerName + " would like:";
        customerTomatoText.text = listOfCustomers[0].numWantedTomatoes.ToString();
        customerPotatoText.text = listOfCustomers[0].numWantedPotatoes.ToString();
        customerCarrotText.text = listOfCustomers[0].numWantedCarrots.ToString();

    } // End of Awake()

    public void FufillRequest()
    {
        // Make sure UI is accurate
        gameManger.UpdateProduceInventoryUI();

        // The player has enough produce for the request
        if (gameManger.numOfTomatoes >= listOfCustomers[currentCustomer].numWantedTomatoes && gameManger.numOfPotatoes >= listOfCustomers[currentCustomer].numWantedPotatoes && gameManger.numOfCarrots >= listOfCustomers[currentCustomer].numWantedCarrots)
        {
            if (currentCustomer < listOfCustomers.Length-1)
            {
                gameManger.numOfTomatoes -= listOfCustomers[currentCustomer].numWantedTomatoes;
                gameManger.numOfPotatoes -= listOfCustomers[currentCustomer].numWantedPotatoes;
                gameManger.numOfCarrots -= listOfCustomers[currentCustomer].numWantedCarrots;
                gameManger.UpdateProduceInventoryUI();

                currentCustomer++;
                customerText.text = listOfCustomers[currentCustomer].customerName + " would like:";
                customerTomatoText.text = listOfCustomers[currentCustomer].numWantedTomatoes.ToString();
                customerPotatoText.text = listOfCustomers[currentCustomer].numWantedPotatoes.ToString();
                customerCarrotText.text = listOfCustomers[currentCustomer].numWantedCarrots.ToString();
            }
            // No more customers
            else
            {
                customerText.text = "No more customer request!";
                customerTomatoText.text = "";
                customerPotatoText.text = "";
                customerCarrotText.text = "";
            }
        }
        else
        {
            StartCoroutine(RequestFeedback());
        }

    } // End of FufillRequest()

    IEnumerator RequestFeedback()
    {
        feedbackCanvasGroup.alpha = 1f;
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());

    } // End of RequestFeedback()

    IEnumerator FadeOut()
    {
        while (feedbackCanvasGroup.alpha > 0f)
        {
            feedbackCanvasGroup.alpha -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }

    } // End of FadeOut()

}
