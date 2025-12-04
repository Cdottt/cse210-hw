using System;
using System.Collections.Generic;

public class Comment
{
    string _name;
    string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetCommentInfo()
    {
        return $"{_name}: {_text}";
    }
}