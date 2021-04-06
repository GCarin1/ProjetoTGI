

using UnityEngine;
using UnityEngine.EventSystems;

    public class DragAndDrop : MonoBehaviour, IPointerDownHandler ,IBeginDragHandler,IEndDragHandler
    {
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _grab;
    [SerializeField] private AudioClip _drop;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _as.clip = _grab;
        _as.Play();
        _canvasGroup.alpha= 0.5f;
       _canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta/_canvas.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Apertou");
    }
}
