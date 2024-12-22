using UnityEngine;
public class SinGame : Puzzle
{
    public Sin_Graph AnswerGraph;
    public Sin_Graph Graph;
    public RotatingButton[] buttons;
    private float timer = 0f;
    void OnDisable()
    {
        timer = 0f;
    }
    void Update()
    {
        if (Mathf.Abs(AnswerGraph.amplitude - Graph.amplitude) < 0.05f)
        {
            if (Mathf.Abs(AnswerGraph.frequency - Graph.frequency) < 0.15f)
            {
                timer += Time.deltaTime;
                if (timer > 1f) ClosePanel();
            } else timer = 0;
        } else timer = 0;
            
        Graph.amplitude = buttons[0].value * 3f - 1.5f;
        Graph.frequency = buttons[1].value * 9f + 1f;
    }
}