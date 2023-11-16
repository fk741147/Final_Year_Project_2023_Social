using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIController : MonoBehaviour,IDragHandler
{
    public RectTransform leftPanel, rightPanel,mainPanel;
    public float minRightPanelWidth ;
    public float minLeftPanelWidth;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel = transform.parent.GetComponent<RectTransform>(); 
        leftPanel.sizeDelta = new Vector2(mainPanel.sizeDelta.x/2, leftPanel.sizeDelta.y);
        rightPanel.sizeDelta = new Vector2(mainPanel.sizeDelta.x / 2, rightPanel.sizeDelta.y);
        minLeftPanelWidth = mainPanel.sizeDelta.x / 3;
        minRightPanelWidth = mainPanel.sizeDelta.x / 3;

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


        if (rightPanelWidth < minRightPanelWidth)
        {
            rightPanelWidth = minRightPanelWidth;
            leftPanelWidth = mainPanel.sizeDelta.x - rightPanelWidth;
        }
        if(leftPanelWidth< minLeftPanelWidth)
        {
            leftPanelWidth = minLeftPanelWidth;
            rightPanelWidth= mainPanel.sizeDelta.x-leftPanelWidth;
        }

        float totalWidth = leftPanelWidth + rightPanelWidth;


        leftPanel.sizeDelta = new Vector2(leftPanelWidth, leftPanel.sizeDelta.y);
        rightPanel.sizeDelta = new Vector2(rightPanelWidth, rightPanel.sizeDelta.y);

        float dividerPosition = leftPanelWidth - totalWidth * 0.5f;
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(dividerPosition, 0);
    }
}
