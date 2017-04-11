using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libZPlay;

namespace Audio.Controller
{
    class TestDrive
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Playing test.mp3. Press Q to quit.\n");
            // create ZPlay class
            ZPlay player = new ZPlay();
            // open file
            if (player.AddFile("1.mp3", TStreamFormat.sfAutodetect) == false)
            {
                Console.WriteLine(player.GetError());
                return;
            }


            // get song length
            TStreamInfo info = new TStreamInfo();
            player.GetStreamInfo(ref info);
            Console.WriteLine("Length: {0:G}:{1:G}:{2:G}:{3:G}",
                info.Length.hms.hour,
                info.Length.hms.minute,
                info.Length.hms.second,
                info.Length.hms.millisecond);

            // start playing
            player.StartPlayback();

            TStreamStatus status = new TStreamStatus();
            TStreamTime time = new TStreamTime();
            status.fPlay = true;

            while (status.fPlay)
            {
                player.GetPosition(ref time);
                Console.Write("Pos: {0:G}:{1:G}:{2:G}:{3:G}\r",
                    time.hms.hour,
                    time.hms.minute,
                    time.hms.second,
                    time.hms.millisecond);
                player.GetStatus(ref status);
                System.Threading.Thread.Sleep(50);
                if (Console.KeyAvailable)
                {
                    var cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Q)
                    {
                        player.StopPlayback();
                    }
                }
            }
        }
    }
}
