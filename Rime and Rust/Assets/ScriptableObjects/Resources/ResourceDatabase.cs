using UnityEngine;
using NorskaLib.Spreadsheets;

[CreateAssetMenu(fileName = "ResourceDatabase", menuName = "Scriptable Objects/ResourceDatabase")]
public class ResourceDatabase : SpreadsheetsContainerBase
{
    [SpreadsheetContent]
    [SerializeField] ResourceSpreadsheetData content;
    public ResourceSpreadsheetData Content => content;
}
