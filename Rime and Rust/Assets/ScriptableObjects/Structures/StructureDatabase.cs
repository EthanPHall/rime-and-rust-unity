using UnityEngine;
using NorskaLib.Spreadsheets;

[CreateAssetMenu(fileName = "StructureDatabase", menuName = "Scriptable Objects/StructureDatabase")]
public class StructureDatabase : SpreadsheetsContainerBase
{
    [SpreadsheetContent]
    [SerializeField] StructureSpreadsheetData content;
    public StructureSpreadsheetData Content => content;
}
