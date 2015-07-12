using System;
using System.Collections.Generic;
using System.Media;
using WMPLib;

namespace projTwitchBot
{
    class StreamCommands
    {
        public void PingPong(String buf, System.IO.TextWriter output)
        {
            //Send pong reply to any ping messages
            if (buf.Contains("PING"))
            {
                output.Write(buf.Replace("PING", "PONG") + "\r\n");
                output.Flush();
            }
        }

        public void Ding(string buf)
        {
            if (Filter(buf).Contains("!donkeymash"))
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        public void Dong(string buf)
        {
            if (Filter(buf).Contains("!Dong"))
            {
                //new SoundPlayer(@"Sounds\WTD.wav").Play(); .WAV
                WMPLib.WindowsMediaPlayer a = new WMPLib.WindowsMediaPlayer(); //.mp3
                a.URL = @"Sounds\WTD.mp3";
                a.controls.play();
            }
        }

        public string Filter(string buf)//Removes all irc server related text
        {
            int i = 0, j = 0;
            List<char> charList = new List<char>();
            charList.AddRange(buf.ToCharArray());
            charList.RemoveAt(0);
            do
            {
                if (charList[i].Equals(':') & (j < 1))
                {
                    break;
                }
                else
                {
                    charList.RemoveAt(0);
                }

            } while (i < charList.Count);

            char[] text = charList.ToArray();
            buf = new String(text);
            charList = null;
            text = null;
            return buf;
        }
    }
}
