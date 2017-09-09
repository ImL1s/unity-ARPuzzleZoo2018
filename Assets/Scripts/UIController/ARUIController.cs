using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class ARUIController : MonoBehaviour
{
    private Button btnFocus;
    private Button btnIdle;
    private Button btnMotion1;
    private Button btnMotion2;
    private Button btnToEBook;


    void Awake()
    {
        InitUIRef();
        InitUIEvent();
    }
}

/// <summary>
/// init method
/// </summary>
partial class ARUIController
{
    void InitUIRef()
    {
        btnFocus = transform.Find("group/btn_focus").GetComponent<Button>();
        btnIdle = transform.Find("group/btn_idle").GetComponent<Button>();
        btnMotion1 = transform.Find("group/btn_motion1").GetComponent<Button>();
        btnMotion2 = transform.Find("group/btn_motion2").GetComponent<Button>();
        btnToEBook = transform.Find("group/btn_to_ebook").GetComponent<Button>();
    }


    private void InitUIEvent()
    {
        //btnFocus.onClick.AddListener(() => NextPage());
        //btnIdle.onClick.AddListener(() => PreviousPage());
        //btnMotion1.onClick.AddListener(() => BackToMain());
        //btnMotion2.onClick.AddListener(() => NavigateToARScene());
        btnToEBook.onClick.AddListener(() => NavigateToEBook());
    }
}

/// <summary>
/// UI event
/// </summary>
partial class ARUIController
{
    private void NavigateToEBook()
    {
        SceneManager.LoadScene(ConstantValue.Scenes.EBook);
    }
}
