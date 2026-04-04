using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base()
    {
        _count = 0;
        _prompts = new List<string>();
    }

    public void Run()
    {
    }

    public string GetRandomPrompt()
    {
        return "";
    }

    public List<string> GetListFromUser()
    {
        return new List<string>();
    }
}