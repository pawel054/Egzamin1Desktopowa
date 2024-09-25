using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDesktop
{
    public class AlbumObject
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public int SongsNumber {  get; set; }
        public int Year { get; set; }
        public int DownloadNumber {  get; set; }

        public AlbumObject() { }
        public AlbumObject(string artist, string album, int songsNumber, int year, int downloadNumber)
        {
            Artist = artist;
            Album = album;
            SongsNumber = songsNumber;
            Year = year;
            DownloadNumber = downloadNumber;
        }
    }
}
