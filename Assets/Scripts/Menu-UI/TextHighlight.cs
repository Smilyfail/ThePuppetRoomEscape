using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI text;
    private Color normalColor;
    private Color hoverColor;

    void Start()
    {


    }


    public void OnPointerEnter(PointerEventData eventData) 
    {

        ColorUtility.TryParseHtmlString("#FE0404", out Color hoverColor);
        text.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ColorUtility.TryParseHtmlString("#A40000", out Color normalColor);
        text.color = normalColor;
    }
}
