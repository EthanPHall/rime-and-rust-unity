using UnityEngine;
using NorskaLib.Spreadsheets;
using System;
using System.Collections.Generic;

//[CreateAssetMenu(fileName = "StructureSpreadsheetData", menuName = "Scriptable Objects/StructureSpreadsheetData")]
[Serializable]
public class StructureSpreadsheetData
{
    [SpreadsheetPage("Structures")]
    [SerializeField] List<Structure> Structures;
    [SpreadsheetPage("Structure Passive Generation")]
    [SerializeField] List<StructureResourcePair> PassiveProduction;
    [SpreadsheetPage("Structure Crafting")]
    [SerializeField] List<StructureResourcePair> CraftableItems;
}
