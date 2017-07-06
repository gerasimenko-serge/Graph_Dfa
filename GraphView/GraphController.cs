using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphImplementation;
using System.IO;
using System.Windows.Forms;

namespace GraphView
{
    public static class GraphController
    {
        /// <summary>
        /// Создает новый граф из файла.
        /// </summary>
        /// <param name="FileName">Путь к файлу</param>
        /// <returns>Возвращает граф, загруженный из файла</returns>
        public static void LoadFromFile(ref Graph g, String FileName)
        {
            String[] lines = File.ReadAllLines(FileName);
            
            Int32 cursor = 0;
            Int32[,] Matr = new Int32[Convert.ToInt32(lines[cursor]), Convert.ToInt32(lines[cursor])];
            cursor++;
            cursor += Matr.GetLength(0);
            for (int i = 0; i < Matr.GetLength(0); i++)
            {
                for (int j = 0; j < Matr.GetLength(1); j++)
                {
                    Matr[i, j] = Convert.ToInt32(lines[cursor]);
                    cursor++;
                }
            }
            cursor = 1;
            g.GraphFromMatrix(Matr);
            foreach(Vertex v in g.Simple())
            {
                v.Value = lines[cursor];
                cursor++;
            }

        }
        /// <summary>
        /// Сохраняет граф в файл
        /// </summary>
        /// <param name="graph">Граф для сохранения</param>
        /// <param name="FileName">Путь к файлу</param>
        public static void SaveToFile(Graph graph, String FileName)
        {
            
            StreamWriter sw = new StreamWriter(FileName);
            String[,] Matr = graph.GetMatrix();
            sw.WriteLine(Matr.GetLength(0).ToString() );
   

            foreach (Vertex ver in graph.Simple())
            {
                sw.WriteLine(ver.Value);
                sw.WriteLine(ver.IsFinish);
                sw.WriteLine(ver.IsStart);
            }

            for(int i = 0; i < Matr.GetLength(0);i++)
            {
                for (int j = 0; j < Matr.GetLength(1); j++)
                {
                    sw.WriteLine(Matr[i,j]);
                }
            }
            sw.WriteLine(graph.edges.Count);
            sw.WriteLine(graph.edges.Count);

            sw.Close();
        }

        public static void Save(ref Graph g)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Сохранить граф.",
                Filter = "Файл графа (*.gr)|*.gr"
            };
            DialogResult dr = sfd.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                SaveToFile(g, sfd.FileName);
            }
        }

        public static void Open(ref Graph g)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Открыть граф.",
                Filter = "Файл графа (*.gr)|*.gr"
            };
            DialogResult dr = ofd.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                g.Clear();
                LoadFromFile(ref g, ofd.FileName);
            }
        }
    }
}
