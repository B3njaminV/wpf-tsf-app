using System;
using System.Collections.Generic;
using TSF_Models;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace TSF_PersDataContract
{
    public class DataContract : IPersistance
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//Persistance");

        public string FileName { get; set; } = "cinema.xml";

        string fichier => Path.Combine(FilePath, FileName);

        public IEnumerable<Cinema> ChargeCinema()
        {
            if (!File.Exists(fichier))
            {
                throw new Exception("Le fichier n'existe pas !");
            }

            var serializer = new DataContractSerializer(typeof(IEnumerable<Cinema>));

            IEnumerable<Cinema> cinema;

            using (Stream stream = File.OpenRead(fichier))
            {
                cinema = serializer.ReadObject(stream) as IEnumerable<Cinema>;
            }

            return cinema;
        }

        public void EnregistreCinema(IEnumerable<Cinema> cinemas)
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(IEnumerable<Cinema>));

            using (Stream stream = File.Create(fichier))
            {
                serializer.WriteObject(stream, cinemas);
            }
        }
    }
}
