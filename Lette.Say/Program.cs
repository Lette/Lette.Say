using System;
using System.IO;
using System.Speech.Synthesis;

namespace Lette.Say
{
    internal class Program
    {
        private static bool _echoLinesToConsole;

        private static void Main(string[] args)
        {
            if (args[0].ToLower() == "-f")
            {
                if (args[0] == "-F")
                {
                    _echoLinesToConsole = true;
                }

                SpeakFile(args[1]);
            }
            else
            {
                SpeakLine(string.Join(" ", args));
            }
        }

        private static void SpeakLine(string textToSpeak)
        {
            using (var speech = new SpeechSynthesizer())
            {
                speech.Speak(textToSpeak);
            }
        }

        private static void SpeakFile(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                if (_echoLinesToConsole)
                {
                    Console.Out.WriteLine(line);
                }
                SpeakLine(line);
            }
        }
    }
}