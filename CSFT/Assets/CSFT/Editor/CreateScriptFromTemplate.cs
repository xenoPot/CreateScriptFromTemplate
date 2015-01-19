using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using System;

/// <summary>
/// 各プロジェクト用のスクリプトテンプレートを用意＆使用するためのエディタ拡張
/// </summary>
static public class CreateScriptFromTemplate {
    /// <summary>
    /// C#の新規スクリプト生成
    /// priority は C# Script の上に来るように適当に調整
    /// </summary>
    [MenuItem( "Assets/Create/C# Script from user template", false, 80 )]
    static public void SelectCSharp()
    {
        CreateScript( "Assets/CSFT/C#ScriptTemplate.txt", ".cs" );
    }

    /// <summary>
    /// 指定したテンプレートファイルを使ってスクリプト生成を行う
    /// </summary>
    /// <param name="templatePath">テンプレートファイルのパス</param>
    /// <param name="extention">生成ファイルの拡張子</param>
    static private void CreateScript( string templatePath, string extention ){
        var DoCreateScriptAsset = Type.GetType(
            "UnityEditor.ProjectWindowCallback.DoCreateScriptAsset, UnityEditor");
        UnityEditor.ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0, 
            ScriptableObject.CreateInstance(DoCreateScriptAsset) as EndNameEditAction,
            "NewBehaviourScript" + extention,
            null,
            templatePath );
    }

}
