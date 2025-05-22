using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "Scriptable Objects/CardSO")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public int cardPower;
    public CardType cardType;
    public Material cardMaterial;
}


public enum CardType 
{
    Club,
    Spade,
    Diamond,
    Heart
}
