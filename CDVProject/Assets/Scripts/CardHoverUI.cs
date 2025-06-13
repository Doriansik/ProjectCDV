using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private float hoverSpeed;

    private Image cardImage;
    private Vector3 targetTransform;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        cardImage = GetComponent<Image>();
        cardImage.sprite = backSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetTransform = new Vector3(1.6f, 1.6f, 1.6f);
        Lerping(targetTransform);
        cardImage.sprite = frontSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetTransform = new Vector3(1f, 1f, 1f);
        Lerping(targetTransform);
        cardImage.sprite = backSprite;
    }

    private void Lerping(Vector3 targetPos)
    {
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetTransform, Time.deltaTime * hoverSpeed);
    }
}
