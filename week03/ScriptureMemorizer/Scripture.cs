using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] pieces = text.Split(" ");

        foreach (string piece in pieces)
        {
            Word word = new Word(piece);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> availableIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                availableIndexes.Add(i);
            }
        }

        if (availableIndexes.Count < numberToHide)
        {
            numberToHide = availableIndexes.Count;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int randomPosition = _random.Next(availableIndexes.Count);
            int wordIndex = availableIndexes[randomPosition];

            _words[wordIndex].Hide();
            availableIndexes.RemoveAt(randomPosition);
        }
    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + " ";

        for (int i = 0; i < _words.Count; i++)
        {
            text += _words[i].GetDisplayText();

            if (i < _words.Count - 1)
            {
                text += " ";
            }
        }

        return text;
    }

    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                return false;
            }
        }

        return true;
    }
}