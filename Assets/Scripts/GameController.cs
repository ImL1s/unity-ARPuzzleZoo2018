/*
 * Copyright (c) 2017  All Rights Reserved.
 *
 * CLR版本： 4.0.30319.42000
 * 機器名稱：DESKTOP-IML1S
 * 文件名：  GameController
 * 版本號：  V1.0.0.0
 * 唯一標識：bdd46acd-3825-48d8-b23e-5316a2052ac7
 * 創建人：  ImL1s
 * 電子郵箱：aa22396584@gmail.com
 * 創建時間：2017/9/10 上午 12:16:53
 * 描述：
 * 
 */

using UnityEngine;


public class GameController : MonoBehaviour
{
    public ConstantValue.EBookAnimal CurrentSelectedAnimal { get; set; }

    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject temp = GameObject.Find("[Game Manager]");
                if (temp == null)
                {
                    temp = new GameObject("[Game Manager]");
                    instance = temp.AddComponent<GameController>();
                }
                else if (instance == null)
                {
                    instance = GameObject.Find("[Game Manager]").AddComponent<GameController>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
    }
}

