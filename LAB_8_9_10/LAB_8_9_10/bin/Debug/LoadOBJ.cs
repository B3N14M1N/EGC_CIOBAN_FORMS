using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_winforms_z03
{
    public struct MeshData {
        public List<Vector3> vertex;
        public List<Vector3> faces;
    };
    public class LoadOBJ
    {
        private const char DELIMITATOR_OBJ = ' ';
        public MeshData ReadOBJ(string FileName)
        {
            List<Vector3> vertex = new List<Vector3>();
            List<Vector3> faces = new List<Vector3>();
            string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string completePath = solutionPath + "\\Models\\" + FileName;
            Stream streamOBJFile = File.Open(completePath, FileMode.OpenOrCreate);
            streamOBJFile.Close();

            using (StreamReader streamReader = new StreamReader(completePath))
            {
                string fileLine;
                // Citeste linia si creaza un vector3
                while ((fileLine = streamReader.ReadLine()) != null)
                {
                    if (fileLine.Split(DELIMITATOR_OBJ).Count() == 4)
                    {
                        var date = fileLine.Split(DELIMITATOR_OBJ);
                        if (date[0] == "v")
                            vertex.Add(new Vector3((float)Convert.ToDouble(date[1].Trim()),
                                    (float)Convert.ToDouble(date[2].Trim()),
                                    (float)Convert.ToDouble(date[3].Trim())));
                        else if (date[0] == "f")
                            faces.Add(new Vector3(Convert.ToInt32(date[1].Trim()),
                                    Convert.ToInt32(date[2].Trim()),
                                    Convert.ToInt32(date[3].Trim())));
                    }
                }
            }
            MeshData meshData = new MeshData();
            meshData.vertex = vertex;
            meshData.faces = faces;
            return meshData;
        }
    }
}
