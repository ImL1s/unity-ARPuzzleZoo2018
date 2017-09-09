using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UnityEngine.SceneManagement;

public partial class MainUIController : MonoBehaviour
{
    private Button btnFox;
    private Button btnGazelle;
    private Button btnLemur;
    private Button btnChameleon;
    private Button btnBoar;

    private Subject<string> onClickSource = new Subject<string>();

    void Awake()
    {
        InitUIRef();
        InitUIEvent();
        InitRxEvent();
    }
}

/// <summary>
/// init
/// </summary>
partial class MainUIController
{
    void InitUIRef()
    {
        btnFox = transform.Find("btn_fox").GetComponent<Button>();
        btnGazelle = transform.Find("btn_gazelle").GetComponent<Button>();
        btnLemur = transform.Find("btn_lemur").GetComponent<Button>();
        btnChameleon = transform.Find("btn_chameleon").GetComponent<Button>();
        btnBoar = transform.Find("btn_boar").GetComponent<Button>();
    }

    void InitUIEvent()
    {
        btnFox.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Fox;
            onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        btnGazelle.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Gazelle;
            onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        btnLemur.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Lemur;
            onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        btnChameleon.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Chameleon;
            onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        btnBoar.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Boar;
            onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
    }

    private void InitRxEvent()
    {
        onClickSource
            .ThrottleFirst(TimeSpan.FromMilliseconds(2000))
            .Subscribe(x => SceneManager.LoadScene(x));
    }

}
