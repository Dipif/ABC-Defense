using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UpDownButton : MonoBehaviour
{
    [SerializeField]
    private RectTransform towerShopTransform;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private bool isUpButton = false;
    public void OnClick()
    {
        if (isUpButton)
        {
            towerShopTransform.DOAnchorPosY(30, 0.5f);
            buttonText.text = "¡å";
            isUpButton = false;
        }
        else
        {
            towerShopTransform.DOAnchorPosY(-300, 0.5f);
            buttonText.text = "¡ã";
            isUpButton = true;
        }
    }
}
