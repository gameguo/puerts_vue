﻿#if UNITY_EDITOR
#define START_DEBUG
#endif

using Puerts;
using UnityEngine;

public delegate void JsEnvInit(JsEnvManager monoBehaviour);
public class JsEnvManager : MonoBehaviour
{
    public GameObject canvas;
    public string jsPath = "G:/Unity/Git/puerts_react/Js/build";
    public string jsName = "main";
    private JsEnv jsEnv;
#if START_DEBUG
    async
#endif
    private void Start()
    {
        jsEnv = new JsEnv(new JsEnvLoader(jsPath), 8080);
#if START_DEBUG
        Debug.Log("等待连接调试...");
        await jsEnv.WaitDebuggerAsync();
        Debug.Log("成功连接！");
#endif
        var init = jsEnv.Eval<JsEnvInit>(@"const main = require('"+ jsName + "'); main.init;");
        if (init != null) init(this);
    }
    private void Update()
    {
        jsEnv.Tick();
    }
    private void OnDestroy()
    {
        jsEnv.Dispose();
    }
}
