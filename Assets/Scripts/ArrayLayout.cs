using UnityEngine;

/// <summary>
/// Moeglichkeit ein Level als 2-dim bool Array zu erstellen.
/// </summary>
[System.Serializable]
public class ArrayLayout
{
    /// <summary>
    /// Versuch die Breite zu definieren
    /// </summary>
    public int width;

    /// <summary>
    /// Versuch die Hoehe zu definieren
    /// </summary>
    public int height;

    [System.Serializable]
    public struct rowData
    {
        public bool[] row;
    }

    public Grid grid;
    public rowData[] rows = new rowData[14]; //Grid of 9x14
}
