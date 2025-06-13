using System.Collections.Generic;
using System.Collections;
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
            StartCoroutine(EndGame());
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
        
        int originalPlayerPower = playerCard.cardPower;
        int originalComputerPower = computerCard.cardPower;

        ApplyCardEffect(playerCard, true);
        ApplyCardEffect(computerCard, false);
        DisplayCardName(playerCard);
        CompareCards(playerCard, computerCard);

        playerCard.cardPower = originalPlayerPower;
        computerCard.cardPower = originalComputerPower;
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
            playerPointsText.text = "Points: " + playerPoints.ToString();

            remainingCardsList.Add(computerCard);
        }
        else if (playerCard.cardPower < computerCard.cardPower)
        {
            computerCardNameText.text = computerInfo;
            resultText.text = " PRZEGRANA!";
            computerPoints++;
            computerPointsText.text = "Points: " + computerPoints.ToString();

            computerRemainingCardsList.Add(playerCard);
        }
        else
        {
            computerCardNameText.text = computerInfo;
            resultText.text = " REMIS!";

            List<CardSO> changeList = remainingCardsList;
            remainingCardsList = computerRemainingCardsList;
            computerRemainingCardsList = changeList;
            Debug.Log("List changes");
        }
    }

    


    private void ApplyCardEffect(CardSO card, bool isPlayer)
    {
        switch (card.cardEffect)
        {
            case CardEffect.None:
                break;
            case CardEffect.DoublePower:
                card.cardPower *= 2;
                Debug.Log(card.effectDescription);
                break;
            case CardEffect.StealPoint:
                if (isPlayer && computerPoints > 0)
                {
                    computerPoints--;
                    playerPoints++;
                    Debug.Log(card.effectDescription);
                }
                else if (!isPlayer && playerPoints > 0)
                {
                    playerPoints--;
                    computerPoints++;
                    Debug.Log(card.effectDescription);
                }
                break;

        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        MenuManager.Instance.GoToMenu();
    }
}
