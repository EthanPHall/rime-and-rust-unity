using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneNavButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI text;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Buh");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontStyle |= FontStyles.Underline;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontStyle &= ~FontStyles.Underline;
    }
}
