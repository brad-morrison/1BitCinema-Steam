using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour
{
    public string name;
    public List<GameObject> subMenuButtons;
    public float subMenuButtonOffset;
    public bool subMenuOpen;
    public float subMoveSpeed;
    public GameObject subMenuHighlighter;

    public UnityEvent mouseOver, mouseOff;

    private void Awake()
    {
        // Get sub buttons
        foreach (MenuButton mb in transform.GetComponentsInChildren<MenuButton>())
        {
            if (mb != this)
                subMenuButtons.Add(mb.gameObject);
        }
        
    }

    private void Start()
    {
        HideChildren();
    }

    private void HideChildren()
    {
        foreach(GameObject mb in subMenuButtons)
        {
            mb.GetComponent<BoxCollider2D>().enabled = false;
            mb.transform.position = gameObject.transform.position;
        }
    }

    private void OpenSubMenu()
    {
        subMenuOpen = true;
        float offsetIncrement = subMenuButtonOffset;
        subMenuHighlighter.SetActive(false);

        foreach (GameObject mb in subMenuButtons)
        {
            mb.transform.DOLocalMoveY(offsetIncrement, subMoveSpeed).SetEase(Ease.OutBack);
            offsetIncrement = offsetIncrement + subMenuButtonOffset;
            StartCoroutine(ActivateCollider(mb));
        }
    }

    private void CloseSubMenu()
    {
        subMenuOpen = false;
        subMenuHighlighter.SetActive(true);
        foreach (GameObject mb in subMenuButtons)
        {
            mb.GetComponent<BoxCollider2D>().enabled = false;
            mb.transform.DOMoveY(gameObject.transform.position.y, subMoveSpeed).SetEase(Ease.InBack);
        }
    }

    private void OnMouseOver()
    {
        Controller.instance.infoText.GetComponent<TextMeshPro>().text = name;
        mouseOver.Invoke();
    }

    private void OnMouseExit()
    {
        Controller.instance.infoText.GetComponent<TextMeshPro>().text = "";
        mouseOff.Invoke();
    }

    private void OnMouseDown()
    {
        if (subMenuOpen == false)
            OpenSubMenu();
        else
            CloseSubMenu();
    }

    IEnumerator ActivateCollider(GameObject subButton)
    {
        yield return new WaitForSeconds(subMoveSpeed);
        subButton.GetComponent<BoxCollider2D>().enabled = true;
    }

}
