using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class TextHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;
    private Color normalColor;
    private Color hoverColor;

    private Color normalTextColor;
    private Color hoverTextColor;

    void Start()
    {

    }

    void Update()
    {

    }


    public void OnPointerEnter(PointerEventData eventData) 
    {

        ColorUtility.TryParseHtmlString("#FF0021", out Color hoverColor);
        ColorUtility.TryParseHtmlString("#FF0000", out Color hoverTextColor);

        if(image != null)
        {

            image.color = hoverColor;

        } else
        {
            text.color = hoverTextColor;

        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out Color normalColor);
        ColorUtility.TryParseHtmlString("#830000", out Color normalTextColor);

        if(image != null)
        {

            image.color = normalColor;

        } else
        {

            text.color = normalTextColor;

        }

    }
}
