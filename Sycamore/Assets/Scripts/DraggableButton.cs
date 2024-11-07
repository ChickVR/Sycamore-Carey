using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TMP_Text[] targetTexts; // Assign the 4 Text elements here
    private const float SnapThreshold = 2f; // Distance within which the button will snap to a text element

    private Vector2 _originalPosition;
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private TMP_Text _buttonText;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _originalPosition = _rectTransform.anchoredPosition;
        _buttonText = GetComponentInChildren<TMP_Text>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalPosition = _rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        TMP_Text closestText = null;
        float closestDistance = Mathf.Infinity;
        
        Vector2 screenPoint = eventData.position; // Get the pointer position in screen space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform, 
            screenPoint, 
            eventData.pressEventCamera, 
            out Vector2 localPoint
        );

        foreach (var targetText in targetTexts)
        {
            float distance = Vector2.Distance(localPoint, targetText.rectTransform.anchoredPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestText = targetText;
            }
        }
        
        if (closestText != null && closestDistance <= SnapThreshold)
        {
            _rectTransform.anchoredPosition = closestText.rectTransform.anchoredPosition;
        }
        else
        {
            _rectTransform.localPosition = localPoint;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TMP_Text closestText = null;
        float closestDistance = Mathf.Infinity;

        foreach (var targetText in targetTexts)
        {
            float distance = Vector2.Distance(_rectTransform.anchoredPosition, targetText.rectTransform.anchoredPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestText = targetText;
            }
        }
        
        Debug.Log(closestDistance);

        if (closestText != null && closestDistance <= SnapThreshold && !closestText.GetComponent<TextTypingEffect>().used)
        {
            //_rectTransform.anchoredPosition = closestText.rectTransform.anchoredPosition;
            closestText.GetComponent<TextTypingEffect>().AnimateText(_buttonText);
            gameObject.SetActive(false);
        }
        else
        {
            _rectTransform.anchoredPosition = _originalPosition;
        }
    }
}