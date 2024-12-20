using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrinterInterface : MonoBehaviour
{
    public GameObject printerUIPanel;
    public Button[] objectCreationButtons;
    public Button[] colorButtons;
    public Sprite objectToBeCreatedSprite;

    private Printer printer;

    void Start()
    {
        if (printer == null)
            printer = new Printer();

        List<Cell> cells = new List<Cell>();
        foreach (Button btn in objectCreationButtons)
        {
            btn.onClick.AddListener(() => OnButtonClick(btn));
            Cell cell = btn.GetComponent<Cell>();
            cells.Add(cell);
        }
        colorButtons[0].onClick.AddListener(() => ChangeColorOfMap(MapColorEnum.Red));
        colorButtons[1].onClick.AddListener(() => ChangeColorOfMap(MapColorEnum.Green));
        colorButtons[2].onClick.AddListener(() => ChangeColorOfMap(MapColorEnum.Blue));

        printer.InitializeArrayOfCells(cells.ToArray());

        ChangeColorOfMap(MapColorEnum.Red);
    }

    void OnButtonClick(Button clickedButton)
    {
        Cell cell = clickedButton.GetComponent<Cell>();
        // printer.ChangeStatusOfCell(cell);
        cell.ChangeStatus();
        cell.ChangeColor(printer.MapColor);
    }
    public void ChangeColorOfMap(MapColorEnum color)
    {
        printer.ChangeColorOfMap(color);
        printer.ApplyColorChanges();
    }
    public void CreateObject()
    {
        printer.CreateObject(objectToBeCreatedSprite);
        printer.ClearArray();
        printer.ApplyColorChanges();
        ClosePanel();
    }

    public void OpenPanel()
    {
        printerUIPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        printerUIPanel.SetActive(false);
    }
}
