using TMPro;
using UnityEngine;

public class TrollExitButton : MonoBehaviour
{
    [SerializeField] private RectTransform buttonRect;
    [SerializeField] private RectTransform movementArea;
    [SerializeField] private TextMeshProUGUI messageText;

    private int clickCount = 0;
    private int maxClicks = 5;

    public void OnExitButtonClick()
    {
        clickCount++;

        if (clickCount < maxClicks)
        {
            MoveButtonToRandomPosition();
        }
        else
        {
            buttonRect.gameObject.SetActive(false);
            messageText.text = "Chcesz wyjœæ?\nKliknij Alt + F4 ";
            messageText.gameObject.SetActive(true);
        }
    }

    void MoveButtonToRandomPosition()
    {
        float areaWidth = movementArea.rect.width - buttonRect.rect.width;
        float areaHeight = movementArea.rect.height - buttonRect.rect.height;

        float randomX = Random.Range(-areaWidth / 2, areaWidth / 2);
        float randomY = Random.Range(-areaHeight / 2, areaHeight / 2);

        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }
}
