using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace GraphImplementation
{
    public class Graph
    {
        #region delegates and events
        public delegate void EventChange(Graph sender);

        /// <summary>
        /// Происходит когда граф был изменен (добавлена или удалена вершина или ребро)
        /// </summary>
        public event EventChange OnChange;

        public delegate void EventVertexRemoved(Graph sender, Vertex vertex);

        /// <summary>
        /// Происходит при удалении  вершины
        /// </summary>
        public event EventVertexRemoved OnVertexRemoved;

        public delegate void EventVertexAdded(Graph sender, Vertex vertex);

        /// <summary>
        /// Происходит при добавлении вершины
        /// </summary>
        public event EventVertexAdded OnVertexAdded;

        public delegate void EventEdgeRemoved(Graph sender, Edge edge);

        /// <summary>
        /// Происходит при удалении ребра
        /// </summary>
        public event EventEdgeRemoved OnEdgeRemoved;

        public delegate void EventEdgeAdded(Graph sender, Edge edge);

        /// <summary>
        /// Происходит при добавлении ребра
        /// </summary>
        public event EventEdgeAdded OnEdgeAdded;

        #endregion

        public List<Vertex> vertexes = new List<Vertex>();
        public List<Edge> edges =  new List<Edge>();

        /// <summary>
        /// Получить вершину по индексу
        /// </summary>
        /// <param name="index">Индекс вершины</param>
        /// <returns>Возвращает вершину, по её индексу</returns>
        public Vertex GetVertextByIndex(int index)
        {
            try
            {
                return vertexes[index];
            }
            catch
            {
                throw new Exception("Неправильный индекс вершины");
            }
        }

        /// <summary>
        /// Стандартный конструктор.
        /// </summary>
        public Graph()
        {
            
        }

        /// <summary>
        /// Создает новый граф на основе матрици смежности Matrix.
        /// </summary>
        /// <param name="Matrix">Матрица смежности.</param>
        public void GraphFromMatrix(Int32[,] Matrix)
        {
            Clear();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                AddVertex();
            }
            for(int i = 0; i < Matrix.GetLength(0);i++)
            {
                for (int j = 0; j < Matrix.GetLength(1);j++)
                {
                    if (Matrix[i,j] == 1)
                    {
                        AddEdge(i, j);
                    }
                }
            }
            
        }

        /// <summary>
        /// Возвращает матрицу смежности графа.
        /// </summary>
        /// <returns>Матрица смежности Int32[,]</returns>
        public String[,] GetMatrix()
        {
            String[,] Matrix = new String[vertexes.Count, vertexes.Count];
            Matrix.Initialize();
            foreach(Vertex ver in vertexes)
            {
                foreach (Vertex inc_ver in ver.Incidented())
                {
                    //Matrix[vertexes.IndexOf(ver), vertexes.IndexOf(inc_ver)] = edges.Find((Edge a)=> {return (a.Vertex1 == ver && a.Vertex2 == inc_ver);}));
                }
            }
            return Matrix;
        }
        /// <summary>
        /// Очищает граф, оставляя его пустым.
        /// </summary>
        public void Clear()
        {
            vertexes.Clear();
        }
        #region "operations with vertexes"
            /// <summary>
            /// Добавляет новую вершину в граф (С данными по умолчанию).
            /// </summary>
            public void AddVertex()
            {
                try
                {
                    Vertex v=new Vertex(vertexes.Count.ToString());
                    vertexes.Add(v);
                    OnVertexAdded?.Invoke(this, v);
                    OnChange?.Invoke(this);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            /// <summary>
            /// Добавляет новую вершину в граф.
            /// </summary>
            /// <param name="Info">Данные для новой вершины.</param>
            public void AddVertex(String Info)
            {
                try
                {
                    Vertex v = new Vertex(Info);
                    vertexes.Add(v);
                    OnVertexAdded?.Invoke(this, v);
                    OnChange?.Invoke(this);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            /// <summary>
            /// Добавляет конкретную вершину в граф.
            /// </summary>
            /// <param name="NewVertex">Вершина для добавления.</param>
            public void AddVertex(Vertex NewVertex)
            {
                try
                {
                    if (!vertexes.Contains(NewVertex)) vertexes.Add(NewVertex);
                    OnVertexAdded?.Invoke(this, NewVertex);
                    OnChange?.Invoke(this);
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            /// <summary>
            /// Удаляет вершину из графа.
            /// </summary>
            /// <param name="DelVertex">Вершина, которую требуется удалить.</param>
            public void RemoveVertex(Vertex DelVertex)
            {
                try
                {
                    OnVertexRemoved?.Invoke(this, DelVertex);
                    List<Edge> fr =  new List<Edge>();
                    foreach (Edge Incident in NeihbourEdges(DelVertex))
                        fr.Add(Incident);
                    foreach (Edge e in fr)
                    {
                        OnEdgeRemoved?.Invoke(this, e);
                        edges.Remove(e);
                    }
                    foreach (Vertex Incident in DelVertex.Incidented())
                          Incident.Vertexes.Remove(DelVertex);
                    vertexes.Remove(DelVertex);
                    OnChange?.Invoke(this);
                }
                catch(Exception e)
                {
                    //throw new Exception(e.Message);
                }
            }
            /// <summary>
            /// Удаляет вершину из графа по указанному индексу
            /// </summary>
            /// <param name="DelIndex">Индекс вершины, которую требуется удалить.</param>
            public void RemoveVertex(Int32 DelIndex)
            {
                try
                {
                    foreach (Vertex Incident in vertexes[DelIndex].Incidented())
                    {
                        OnEdgeRemoved?.Invoke(this, new Edge(Incident, vertexes[DelIndex]));
                        Incident.Vertexes.Remove(vertexes[DelIndex]);
                    }
                    OnVertexRemoved?.Invoke(this, vertexes[DelIndex]);
                    vertexes.Remove(vertexes[DelIndex]);
                    OnChange?.Invoke(this);
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        #endregion
        #region "operation with edges"

            /// <summary>
            /// Добавляет ребро в граф. Если связь уже есть, то удаляет её.
            /// </summary>
            /// <param name="Vertex1">Первая вершина, которая входит в добавляемое ребро.</param>
            /// <param name="Vertex2">Вторая вершина, которая входит в добавляемое ребро.</param>
            public void AddEdge(Vertex Vertex1, Vertex Vertex2)
            {
                try
                {
                    if (!edges.Exists(a => a == new Edge(Vertex1, Vertex2)))
                    {
                        Vertex1.Vertexes.Add(Vertex2);
                        //Vertex2.Vertexes.Add(Vertex1);
                        edges.Add(new Edge(Vertex1, Vertex2));
                        OnEdgeAdded?.Invoke(this, edges.Last());
                        OnChange?.Invoke(this);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            /// <summary>
            /// Добавляет ребро в граф, на основе индексов вершин. Если связь уже есть, то удаляет её.
            /// </summary>
            /// <param name="Index1">Индекс первой вершины, которая входит в добавляемое ребро.</param>
            /// <param name="Index2">Индекс второй вершины, которая входит в добавляемое ребро</param>
            public void AddEdge(Int32 Index1, Int32 Index2)
            {
                Vertex v;
                    try
                    {
                        v = vertexes[Index1];
                        v = vertexes[Index2];
                    }
                    catch
                    {
                        throw new Exception("Индекс кривой!");
                    }
                    if (!edges.Contains(new Edge(vertexes[Index1], vertexes[Index2])))
                    {
                        vertexes[Index1].Vertexes.Add(vertexes[Index2]);
                        //vertexes[Index2].Vertexes.Add(vertexes[Index1]);
                        edges.Add(new Edge(vertexes[Index1], vertexes[Index2]));
                        OnEdgeAdded?.Invoke(this, edges.Last());
                        OnChange?.Invoke(this);
                    }
            }
            /// <summary>
            /// Удаляет ребро соединяющие вершины Vertex1 и Vertex2, если таковые имеется.
            /// </summary>
            /// <param name="Vertex1">Первая вершина.</param>
            /// <param name="Vertex2">Вторая вершина.</param>
            public void RemoveEdge(Vertex Vertex1, Vertex Vertex2)
            {
                try
                {
                    OnEdgeRemoved?.Invoke(this, new Edge(Vertex1, Vertex2));
                    if (Vertex1.Vertexes.Contains(Vertex2)) Vertex1.Vertexes.Remove(Vertex2);
                    if (Vertex2.Vertexes.Contains(Vertex1)) Vertex2.Vertexes.Remove(Vertex1);
                    OnChange?.Invoke(this);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            /// <summary>
            /// Удаляет ребро соединяющие вершины с индексами Index1 и Index2, если таковые имеется.
            /// </summary>
            /// <param name="Index1">Индекс первой вершины.</param>
            /// <param name="Index2">Индекс второй вершины</param>
            public void RemoveEdge(Int32 Index1, Int32 Index2)
            {
                Vertex v;
                if (Index1 != Index2)
                {
                    try
                    {
                        v = vertexes[Index1];
                        v = vertexes[Index2];
                    }
                    catch
                    {
                        throw new Exception("Индекс кривой!");
                    }
                    OnEdgeRemoved?.Invoke(this, new Edge(vertexes[Index1], vertexes[Index2]));
                    if (vertexes[Index1].Vertexes.Contains(vertexes[Index2])) vertexes[Index1].Vertexes.Remove(vertexes[Index2]);
                    if (vertexes[Index2].Vertexes.Contains(vertexes[Index1])) vertexes[Index2].Vertexes.Remove(vertexes[Index1]);
                    OnChange?.Invoke(this);
                }
            }
        #endregion
        /// <summary>
        /// Пустота графа
        /// </summary>
        /// <returns>Возвращает истину, если граф пуст</returns>
        [Description("Показывает является ли граф пустым")]
        public Boolean IsEmpty
        {
            get { return vertexes.Count == 0; }
        }

        #region "iterators"

            /// <summary>
            /// Обход графа по ребрам.
            /// </summary>
            /// <returns>Возвращает все ребра графа.</returns>
            public IEnumerable<Edge> Edges()
            {
                foreach(Edge e in edges)
                    yield return e;
            }
            
            /// <summary>
            /// Перечисляет все вершины инцидентные данной.
            /// </summary>
            /// <param name="CurrentVertex">Вершина.</param>
            /// <returns>Возвращает все инцидентные вершины в произвольном порядке.</returns>
            public IEnumerable<Vertex> Incidented(Vertex CurrentVertex)
            {
                foreach (Vertex ver in CurrentVertex.Vertexes)
                {
                    if (!Equals(ver, CurrentVertex))
                        yield return ver;
                }
            }

            public IEnumerable<Edge> IncidentedEdges(Vertex CurrentVertex)
            {
                foreach (Edge e in edges)
                {
                    if (Equals(e.Vertex1, CurrentVertex))
                        yield return e;
                }
            }

            public IEnumerable<Edge> NeihbourEdges(Vertex CurrentVertex)
            {
                foreach (Edge e in edges)
                {
                    if (Equals(e.Vertex1, CurrentVertex))
                        yield return e;
                    if (Equals(e.Vertex2, CurrentVertex))
                        yield return e;
                }

            } 

            public IEnumerable<Vertex> Neihbours(Vertex CurrentVertex)
            {
                foreach (Edge e in edges)
                {
                    if (Equals(e.Vertex1, CurrentVertex) && !Equals(e.Vertex2, CurrentVertex))
                        yield return e.Vertex2;
                    if (Equals(e.Vertex2, CurrentVertex) && !Equals(e.Vertex1, CurrentVertex))
                        yield return e.Vertex1;
                }

            } 

            /// <summary>
            /// Перечисляет все вершины графа в произвольном порядке.
            /// </summary>
            /// <returns>Возвращает все вершины в произвольном порядке.</returns>
            public IEnumerable<Vertex> Simple()
            {
                foreach (Vertex ver in vertexes)
                {
                    yield return ver;
                }
            }

        #endregion


    }
}
