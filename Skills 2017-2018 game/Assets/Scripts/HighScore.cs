using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public List<string> names = new List<string>();
    public List<int> scores = new List<int>();

    string path = "Assets/Resources/scores.txt";

    public void SaveToFile()
    {
        StreamWriter writer = new StreamWriter(@path);

        for (int i = 0; i < names.Count; i++)
        {
            string output = names[i] + "  " + scores[i].ToString();
            writer.WriteLine(output);
        }

        writer.Close();
    }

    public void ReadFromFile()
    {
        StreamReader reader = new StreamReader(@path);

        string line = reader.ReadLine();

        while(line != null)
        {
            char[] split = { '-' };
            string[] fields = line.Split(split);
            names.Add(fields[0]);
            scores.Add(int.Parse(fields[1]));

            line = reader.ReadLine();
        }
    }

    public void DisplayScores()
    {
        Text[] texts;
        texts = GetComponentsInChildren<Text>();

        for (int i = 0; i < texts.Length; i++)
        {
            Text text = texts[i];

            if(text.tag != "NonHighScoreTextInHighScore")
            {
                text.text = i + 1 + ")" + names[i] + " --- " + scores[i];
            }
        }
    }
}
