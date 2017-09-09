using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// extend mono behaviour
/// </summary>
public partial class EBookUIController : MonoBehaviour
{
    private Image imgContent;
    private Button btnBackToMain;
    private Button btnAR;
    private Button btnPrevious;
    private Button btnNext;
    private int currentPage = 0;
    private int maxPage = 0;


    public List<Sprite> images = new List<Sprite>();

    void Awake()
    {
        InitUIRef();
        LoadResource();
        InitFirstPage();
        InitUIEvent();
    }
}

/// <summary>
/// init method
/// </summary>
partial class EBookUIController
{
    void InitUIRef()
    {
        imgContent = transform.Find("image_content").GetComponent<Image>();
        btnBackToMain = transform.Find("group/btn_back_to_main").GetComponent<Button>();
        btnAR = transform.Find("group/btn_ar").GetComponent<Button>();
        btnPrevious = transform.Find("group/btn_previous").GetComponent<Button>();
        btnNext = transform.Find("group/btn_next").GetComponent<Button>();
    }

    private void LoadResource()
    {
        ConstantValue.EBookAnimal animal = GameController.Instance.CurrentSelectedAnimal;

        for (int i = 1; i < int.MaxValue; i++)
        {
            string path = "ebook/" + animal.ToString().ToLower() + "0" + i;
            Sprite imageRes = Resources.Load<Sprite>(path);

            if (imageRes != null)
            {
                images.Add(imageRes);
            }
            else
            {
                maxPage = (i - 2);
                break;
            }
        }
    }

    private void InitUIEvent()
    {
        btnNext.onClick.AddListener(() => NextPage());
        btnPrevious.onClick.AddListener(() => PreviousPage());
        btnBackToMain.onClick.AddListener(() => BackToMain());
        btnAR.onClick.AddListener(() => NavigateToARScene());
    }

    private void InitFirstPage()
    {
        currentPage = 0;
        imgContent.sprite = images[currentPage];
    }
}

/// <summary>
/// UI event
/// </summary>
partial class EBookUIController
{
    private void NextPage()
    {
        if (currentPage >= maxPage || currentPage >= maxPage) return;
        ++currentPage;
        imgContent.sprite = images[currentPage];
    }

    private void PreviousPage()
    {
        if (currentPage <= 0) return;
        --currentPage;
        imgContent.sprite = images[currentPage];
    }

    private void BackToMain()
    {
        SceneManager.LoadScene(ConstantValue.Scenes.Main);
    }

    private void NavigateToARScene()
    {
        SceneManager.LoadScene(ConstantValue.Scenes.AR);
    }
}
