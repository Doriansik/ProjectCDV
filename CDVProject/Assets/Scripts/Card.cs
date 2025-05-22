using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardSO cardSO;
   
    public CardSO GetCardData()
    {
        return cardSO;
    }

    public void SelectedCard()
    {
        transform.localScale = Vector3.one * 2f;
    }

    public void UnSelectedCard()
    {
        transform.localScale = new Vector3(1f, 1.8f, 0.1f);
    }
}
