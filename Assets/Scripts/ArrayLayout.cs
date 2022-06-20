using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout  {

	public int width;
	public int height;

	[System.Serializable]
	public struct rowData{
		public bool[] row;
	}

    public Grid grid;
    public rowData[] rows = new rowData[14]; //Grid of 9x14
}
