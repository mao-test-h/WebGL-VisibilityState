#if UNITY_WEBGL && !UNITY_EDITOR
#define UNITY_WEBGL_BUILD_ONLY
#endif

using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

/// <summary>
/// 表示状態監視クラス
/// </summary>
public class VisibilityStateChecker : MonoBehaviour
{
#if UNITY_WEBGL_BUILD_ONLY

    /// <summary>
    /// ゲームオブジェクト名
    /// </summary>
    const string GameObjectName = "VisibilityStateChecker";

    /// <summary>
    /// UnityEvent : Start
    /// </summary>
    void Start()
    {
        this.gameObject.name = VisibilityStateChecker.GameObjectName;
        Initialize();
    }

    /// <summary>
    /// プラグインの初期化
    /// </summary>
    [DllImport("__Internal")]
    static extern void Initialize();

    /// <summary>
    /// プラグインからのレスポンス
    /// </summary>
    /// <param name="response">"document.hidden"の値(文字列)</param>
    public void Send(string response)
    {
        Debug.Log("VisibilityState : " + response);
    }

#else

    /// <summary>
    /// UnityEvent : Start
    /// </summary>
    void Start()
    {
        Debug.LogWarning("WebGL Build Only");
        Destroy(this.gameObject);
    }

#endif
}
