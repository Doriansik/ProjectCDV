using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    [Header("CardList")]
    [SerializeField] private List<CardSO> cardsList;
    [SerializeField] private List<CardSO> computerCardsList;
    
    [Header("Renderers")]
    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private Renderer computerRenderer;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI computerCardNameText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI playerPointsText;
    [SerializeField] private TextMeshProUGUI computerPointsText;

    private int playerPoints;
    private int computerPoints;
    private List<CardSO> remainingCardsList;
    private List<CardSO> computerRemainingCardsList;


    private void Awake()
    {
        remainingCardsList = new List<CardSO>(cardsList);
        computerRemainingCardsList = new List<CardSO>(computerCardsList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrawCard();
        }
    }

    private void DrawCard()
    {
        if (remainingCardsList.Count == 0 || computerRemainingCardsList.Count == 0)
        {
            resultText.text = "KONIEC GRY!";
            return;
        }

        int playerIndex = Random.Range(0, remainingCardsList.Count);
        CardSO playerCard = remainingCardsList[playerIndex];
        playerRenderer.material = playerCard.cardMaterial;
        remainingCardsList.RemoveAt(playerIndex);

        int computerIndex = Random.Range(0, computerRemainingCardsList.Count);
        CardSO computerCard = computerRemainingCardsList[computerIndex];
        computerRenderer.material = computerCard.cardMaterial;
        computerRemainingCardsList.RemoveAt(computerIndex);


        DisplayCardName(playerCard);
        CompareCards(playerCard, computerCard);
    }

    private void DisplayCardName(CardSO cardPlayer)
    {
        cardNameText.text = cardPlayer.cardName + " Sila gracza: " + cardPlayer.cardPower;
    }

    private void CompareCards(CardSO playerCard, CardSO computerCard)
    {

        string computerInfo = computerCard.cardName + " Sila komputera: " + computerCard.cardPower;

        if (playerCard.cardPower > computerCard.cardPower)
        {
            computerCardNameText.text = computerInfo;
            resultText.text = " WYGRANA!";
            playerPoints++;
            playerPointsText.text = playerPoints.ToString();

            remainingCardsList.Add(computerCard);
        }
        else if (playerCard.cardPower < computerCard.cardPower)
        {
            computerCardNameText.text = computerInfo;
            resultText.text = " PRZEGRANA!";
            computerPoints++;
            computerPointsText.text = computerPoints.ToString();

            computerRemainingCardsList.Add(playerCard);
        }
        else
        {
            computerCardNameText.text = computerInfo;
            resultText.text = " REMIS!";
        }
    }
}
