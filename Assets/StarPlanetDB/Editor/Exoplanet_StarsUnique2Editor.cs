using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Exoplanet_StarsUnique2))]
public class Exoplanet_StarsUnique2Editor : BaseExcelEditor<Exoplanet_StarsUnique2>
{	    
    public override bool Load()
    {
        Exoplanet_StarsUnique2 targetData = target as Exoplanet_StarsUnique2;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<Exoplanet_StarsUnique2Data>().ToArray();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
