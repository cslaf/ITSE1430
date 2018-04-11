using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    
    class Program
    {
        [STAThread]
        static void Main( string[] args )
        {
            SortedSet<WordData> actuallyTree = new SortedSet<WordData>();

            char[] punctuation = { '.', '.', '!', '?', '(', ')' , ' ' };

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
                    var toAdd = new WordData(word.ToLower().Trim(punctuation));
                    toAdd.lines.Add(lineNum);
                    var existing = actuallyTree.FirstOrDefault(e => e.word.Equals(toAdd.word));
                    if (existing == null)
                        actuallyTree.Add(toAdd);
                    else
                        existing.lines.Add(lineNum);
                }
            }
            actuallyTree.Remove(new WordData(""));
            var toWrite = actuallyTree.Reverse();
            List<string> writeAllLines = new List<string>();
               
            foreach(var thing in toWrite)
            {
                var toAdd = thing.word;
                foreach (var line in thing.lines)
                    toAdd += $" {line} ";
                writeAllLines.Add(toAdd);
            }

            var save = new SaveFileDialog();
            save.FileName = "index.txt";
            save.ShowDialog();
            File.WriteAllLines(save.FileName, writeAllLines);
        }
    }
}
