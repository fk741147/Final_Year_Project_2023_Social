using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIController : MonoBehaviour,IDragHandler
{
    public RectTransform leftPanel, rightPanel;
    public float minRightPanelWidth = 50f;
    public float minLeftPanelWidth = 50f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Test");
        float widthDelta = eventData.delta.x;

        float leftPanelWidth = leftPanel.sizeDelta.x + widthDelta;
        float rightPanelWidth = rightPanel.sizeDelta.x - widthDelta;

        float minRightPanelWidth = 50f;


        if (rightPanelWidth < minRightPanelWidth)
        {
            rightPanelWidth = minRightPanelWidth;
            leftPanelWidth = transform.parent.GetComponent<RectTransform>().sizeDelta.x - rightPanelWidth;
        }
        if(leftPanelWidth< minLeftPanelWidth)
        {
            leftPanelWidth = minLeftPanelWidth;
            rightPanelWidth= transform.parent.GetComponent<RectTransform>().sizeDelta.x-leftPanelWidth;
        }

        float totalWidth = leftPanelWidth + rightPanelWidth;


        leftPanel.sizeDelta = new Vector2(leftPanelWidth, leftPanel.sizeDelta.y);
        rightPanel.sizeDelta = new Vector2(rightPanelWidth, rightPanel.sizeDelta.y);

        float dividerPosition = leftPanelWidth - totalWidth * 0.5f;
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(dividerPosition, 0);
    }
}
