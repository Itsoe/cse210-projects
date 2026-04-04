using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
    }

    public void DisplayEndingMessage()
    {
    }

    public void ShowSpinner(int seconds)
    {
    }

    public void ShowCountDown(int seconds)
    {
    }
}