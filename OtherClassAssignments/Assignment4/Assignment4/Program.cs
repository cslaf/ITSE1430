﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryTree;

namespace Assignment4
{
    
    class Program
    {
        [STAThread]
        static void Main( string[] args )
        {
            var actuallyTree = new BinaryTree<WordData>();

            char[] punctuation = { '.', ',', ';', '!', '?', '(', ')' , ' ' };

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "input.txt";
            openFile.ShowDialog();
            var lines = File.ReadAllLines(openFile.FileName);
            var lineNum = 0;

            foreach(var line in lines)
            {
                lineNum++;
                var words = line.Split(' ');
                foreach(var word in words)
                {
                    if (!String.IsNullOrEmpty(word))
                    {
                        var toAdd = new WordData(word.ToLower().Trim(punctuation));
                        toAdd.lines.Add(lineNum);
                        var existing = actuallyTree.FirstOrDefault(e => 0 == e?.CompareTo(toAdd));
                        if (existing == null)
                            actuallyTree.Add(toAdd);
                        else
                            existing.lines.Add(lineNum);
                    }
                }
            }
            var toWrite = actuallyTree.Reverse();
            List<string> writeAllLines = new List<string>();
               
            foreach(var thing in toWrite)
            {
                if (thing != null)
                {
                    var toAdd = thing.word;
                    foreach (var line in thing.lines)
                        toAdd += $" {line} ";
                    writeAllLines.Add(toAdd);
                }
            }

            var save = new SaveFileDialog();
            save.FileName = "index.txt";
            save.ShowDialog();
            File.WriteAllLines(save.FileName, writeAllLines);
        }
    }
}