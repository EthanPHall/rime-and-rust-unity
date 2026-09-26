using NorskaLib.Spreadsheets;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceSpreadsheetData
{
    [SpreadsheetPage("Items")]
    [SerializeField] List<ResourceData> items;
}
