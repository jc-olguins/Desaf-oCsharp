using Desafio1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaProfes = new List<Profesor>();
            string[] lineas = File.ReadAllLines("./Files/Profesores.txt");

            int localId = 0;

            foreach (var linea in lineas)
            {
                listaProfes.Add(new Profesor { Nombre = linea, Id = localId++ });
            }

            foreach (var profe in listaProfes)
            {
                Console.WriteLine(profe.Nombre);
            }

            var archivo = File.Open("profesBinarios.bin", FileMode.OpenOrCreate);

            var binFile = new BinaryWriter(archivo);

            foreach (var profe in listaProfes)
            {
                binFile.Write(profe.Nombre);
                binFile.Write(profe.Id);
            }

            binFile.Close();
            archivo.Close();
        }
    }
}
