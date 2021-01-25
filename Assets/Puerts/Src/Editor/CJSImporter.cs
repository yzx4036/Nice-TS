#if UNITY_2018_1_OR_NEWER
using System.IO;

using UnityEngine;
 
[UnityEditor.AssetImporters.ScriptedImporter(1, "cjs")]
public class CJSImporter : UnityEditor.AssetImporters.ScriptedImporter
{
    public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
    {
        TextAsset subAsset = new TextAsset(File.ReadAllText(ctx.assetPath));
        ctx.AddObjectToAsset("text", subAsset);
        ctx.SetMainObject(subAsset);

#if ENABLE_CJS_AUTO_RELOAD
        Puerts.JsEnv.ClearAllModuleCaches();
#endif
    }
}

#endif
