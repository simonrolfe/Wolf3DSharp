using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wolf3dSharp.NonWolf.Logging;
using CH.Compressor.Huffman;

namespace Wolf3dSharp
{
    public class GameLoader
    {
        private readonly string _gameDataPath;
        private readonly AbstractLogger _logger;

        public GameLoader(string gameDataPath, AbstractLogger logger)
        {
            _gameDataPath = gameDataPath;
            _logger = logger;
        }

        public bool VerifyGameData()
        {
            //don't care about the commented out ones at the moment.
            return
                //File.Exists(Path.Combine(_gameDataPath, "AUDIOHED.WL6")) &&
                //File.Exists(Path.Combine(_gameDataPath, "AUDIOT.WL6")) &&
                File.Exists(Path.Combine(_gameDataPath, "CONFIG.WL6")) //&&
                //File.Exists(Path.Combine(_gameDataPath, "GAMEMAPS.WL6")) &&
                //File.Exists(Path.Combine(_gameDataPath, "MAPHEAD.WL6")) &&
                //File.Exists(Path.Combine(_gameDataPath, "VGADICT.WL6")) &&
                //File.Exists(Path.Combine(_gameDataPath, "VGAGRAPH.WL6")) &&
                //File.Exists(Path.Combine(_gameDataPath, "VGAHEAD.WL6")) &&
                //File.Exists(Path.Combine(_gameDataPath, "VSWAP.WL6"))
                ;
        }

        public bool LoadAndDecompressFile(string fileName)
        {

        }
    }
}
