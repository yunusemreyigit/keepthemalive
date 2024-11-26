using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MapColorEnum
{
    Red,
    Green,
    Blue,
}
public class Printer
{

    const int arraySize = 3;
    Cell[,] arrayOfCells = new Cell[arraySize, arraySize];
    Color mapColor;

    public Color MapColor { get => mapColor; }

    public void InitializeArrayOfCells(Cell[] inputCellArray)
    {
        int temp = 0;
        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
            {
                Cell cell = inputCellArray[temp];
                arrayOfCells[i, j] = cell;
                cell.Position = new Vector2Int(j, i);
                temp++;
            }
        }
    }
    public void ClearArray()
    {
        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
            {
                arrayOfCells[i, j].ResetStatus();
            }
        }
    }
    public void ChangeStatusOfCell(Cell cell)
    {
        foreach (Cell myCell in arrayOfCells)
        {
            if (myCell.Position == cell.Position)
            {
                myCell.ChangeStatus();
                break;
            }
        }
    }
    public void ChangeColorOfMap(MapColorEnum color)
    {
        switch (color)
        {
            case MapColorEnum.Red:
                mapColor = Color.red;
                break;
            case MapColorEnum.Green:
                mapColor = Color.green;
                break;
            case MapColorEnum.Blue:
                mapColor = Color.blue;
                break;
            default:
                mapColor = Color.white;
                break;
        }
    }
    public void ApplyColorChanges()
    {
        foreach (Cell cell in arrayOfCells)
        {
            cell.ChangeColor(mapColor);
        }
    }
    private List<Cell> GetCellsToBeCreated()
    {
        List<Cell> cellsToBeCreated = new List<Cell>();
        foreach (Cell cell in arrayOfCells)
        {
            if (cell.IsSelected())
            {
                cellsToBeCreated.Add(cell);
            }
        }
        return cellsToBeCreated;
    }
    public void CreateObject(Sprite objectToBeCreatedSprite)
    {
        List<Cell> cells = GetCellsToBeCreated();
        GameObject parentObject = new GameObject("parentObject");
        foreach (Cell cell in cells)
        {
            GameObject objectToBeCreated = ObjectCreateator(mapColor, objectToBeCreatedSprite);
            objectToBeCreated.transform.localPosition = new Vector3(cell.Position.x, cell.Position.y, 0);
            objectToBeCreated.transform.SetParent(parentObject.transform);
        }
    }
    private GameObject ObjectCreateator(Color selectedButtonColor, Sprite objectToBeCreatedSprite)
    {
        GameObject objectToBeCreated = new GameObject();
        SpriteRenderer spriteRenderer = objectToBeCreated.AddComponent<SpriteRenderer>();
        spriteRenderer.color = selectedButtonColor;
        spriteRenderer.sprite = objectToBeCreatedSprite;
        return objectToBeCreated;
    }
}