using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionInspector : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform _panel;
    
    Vector3 _startPosition;
    Vector3 _currentPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = eventData.position;
        _panel.gameObject.SetActive(true);
        _panel.anchorMin = new Vector2(_startPosition.x / Screen.width, _startPosition.y / Screen.height);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentPosition = eventData.position;

        _panel.anchorMin = new Vector2(Mathf.Min(_startPosition.x, _currentPosition.x) / Screen.width, Mathf.Min(_startPosition.y, _currentPosition.y) / Screen.height);
        _panel.anchorMax = new Vector2(Mathf.Max(_startPosition.x, _currentPosition.x) / Screen.width, Mathf.Max(_startPosition.y, _currentPosition.y) / Screen.height);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _panel.gameObject.SetActive(false);
    }
}
