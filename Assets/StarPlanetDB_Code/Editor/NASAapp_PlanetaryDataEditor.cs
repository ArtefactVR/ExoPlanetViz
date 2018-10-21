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
[CustomEditor(typeof(NASAapp_PlanetaryData))]
public class NASAapp_PlanetaryDataEditor : BaseExcelEditor<NASAapp_PlanetaryData>
{
    int junk;
    public override bool Load()
    {
        NASAapp_PlanetaryData targetData = target as NASAapp_PlanetaryData;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<NASAapp_PlanetaryDataData>().ToArray();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
