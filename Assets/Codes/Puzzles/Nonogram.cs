using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Nonogram : Puzzle
{
    const int RowSize = 3;
    const int ColumnSize = 4;
    public Button[] Buttons = new Button[RowSize * ColumnSize];
    public Sprite[] SpritesForButtons;
    public TextMeshProUGUI[] Rows;
    public TextMeshProUGUI[] Columns;
    private bool[,] matrix = new bool[RowSize, ColumnSize];
    private string[] AnswerRows = new string[RowSize];
    private string[] AnswerColumns = new string[ColumnSize];
    private string[] CurrentRows = new string[RowSize];
    private string[] CurrentColumns = new string[ColumnSize];
    public float timer = 0f;
    private bool GameOver = false;

    void Start()
    {
        for (int i = 0; i < RowSize; i++)
            for (int j = 0; j < ColumnSize; j++)
                matrix[i, j] = UnityEngine.Random.Range(0, 2) == 1;

        SetStrings(AnswerRows, AnswerColumns);

        for (int i = 0; i < RowSize; i++)
            Rows[i].SetText(AnswerRows[i]);

        for (int i = 0; i < ColumnSize; i++)
            Columns[i].SetText(AnswerColumns[i]);

        for (int i = 0; i < RowSize; i++)
            for (int j = 0; j < ColumnSize; j++)
            {
                matrix[i,j] = false;
                int x = i, y = j;
                Buttons[x*ColumnSize+y].onClick.AddListener(() => OnButtonClick(x,y));
            }
    }
    void Update()
    {
        if (GameOver)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f) ClosePanel();
        }
    }
    private void SetStrings(string[] rows, string[] columns)
    {
        int counter;
        for (int i = 0; i < RowSize; i++) rows[i] = "";
        for (int i = 0; i < ColumnSize; i++) columns[i] = "";

        for (int i = 0; i < RowSize; i++)
        {
            counter = 0;
            for (int j = 0; j < ColumnSize; j++)
            {
                if (matrix[i, j])
                {
                    counter++;
                    if (j == ColumnSize - 1)
                        rows[i] += counter.ToString();
                }
                else if (counter != 0)
                {
                    rows[i] += counter.ToString() + " ";
                    counter = 0;
                }
            }
            if (rows[i] == "") rows[i] = "0";
        }

        for (int i = 0; i < ColumnSize; i++)
        {
            counter = 0;
            for (int j = 0; j < RowSize; j++)
            {
                if (matrix[j, i])
                {
                    counter++;
                    if (j == RowSize - 1)
                        columns[i] += counter.ToString();
                }
                else if (counter != 0)
                {
                    columns[i] += counter.ToString();
                    counter = 0;
                }
            }
            if (columns[i] == "") columns[i] = "0";
        }
    }
    private void OnButtonClick(int i, int j)
    {
        if (GameOver) return;
        Buttons[i*ColumnSize+j].image.sprite = (matrix[i, j] = !matrix[i, j]) ? SpritesForButtons[1] : SpritesForButtons[0];
        SetStrings(CurrentRows, CurrentColumns);
        if (IsGameOver()) GameOver = true;
    }
    private bool IsGameOver()
    {
        for (int i = 0; i < RowSize; i++)
            if (CurrentRows[i] != AnswerRows[i])
                return false;
        for (int i = 0; i < ColumnSize; i++)
            if (CurrentColumns[i] != AnswerColumns[i])
                return false;
        return true;
    }
}