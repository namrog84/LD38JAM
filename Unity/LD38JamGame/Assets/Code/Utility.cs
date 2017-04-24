using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileInformation
{
    public GameObject GroundTileObject;
    public int NorthId;
    public int SouthId;
    public int EastId;
    public int WestId;

    public TileInformation(GameObject g)
    {
        GroundTileObject = g;
    }

    
};

public interface ITurnInterface
{
    // called at the end of a turn
    void EndTurn();

}

public class Utility {
    

    public static void Shuffle<T>(T[,] array)
    {
        int lengthRow = array.GetLength(1);

        for (int i = array.Length - 1; i > 0; i--)
        {
            int i0 = i / lengthRow;
            int i1 = i % lengthRow;

            int j = Random.Range(0, i + 1);
            int j0 = j / lengthRow;
            int j1 = j % lengthRow;

            T temp = array[i0, i1];
            array[i0, i1] = array[j0, j1];
            array[j0, j1] = temp;
        }
    }
  


}
