using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

public class Journal
{
    private List<Entry> _entryText = new List<Entry>();


    public void AddEntry(Entry entry)
    {
        _entryText.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entryText.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entryText)
        {
            entry.Display();
        }
    }

    //Save File
    public void SaveToFile(string filename)
    {
        //make sure the file is saved in .csv format
        string _filename = $"{filename}.csv";
        using (StreamWriter writer = new StreamWriter(_filename, true))
        {
            foreach (Entry entry in _entryText)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine($"Entries saved to {_filename}.");
    }

    //Load File
    public void LoadFromFile(string filename)
    {
        //make sure the file exists in .csv format
        string _filename = $"{filename}.csv";
        if (File.Exists(_filename))
        {
            _entryText.Clear();
            foreach (string line in File.ReadAllLines(_filename))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entryText.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {_filename}.");
        }
        else
        {
            Console.WriteLine($"File {_filename} does not exist.");
        }
    }
}