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

    //public Animator foxAnimator;
    //public Animator gazelleAnimator;
    //public Animator lemurAnimator;
    //public Animator chameleonAnimator;
    //public Animator boarAnimator;

    public List<Animator> animators;

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
    public

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
        btnIdle.onClick.AddListener(() => PlayIdleAnimation());
        btnMotion1.onClick.AddListener(() => PlayMotion1Animation());
        btnMotion2.onClick.AddListener(() => PlayMotion2Animation());
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

    private void PlayIdleAnimation()
    {
        foreach (var item in animators)
        {
            item.SetInteger("state", ConstantValue.AnimatorState.Idle);
        }
    }

    private void PlayMotion1Animation()
    {
        foreach (var item in animators)
        {
            item.SetInteger("state", ConstantValue.AnimatorState.Motion1);
        }
    }

    private void PlayMotion2Animation()
    {
        foreach (var item in animators)
        {
            item.SetInteger("state", ConstantValue.AnimatorState.Motion2);
        }
    }
}
