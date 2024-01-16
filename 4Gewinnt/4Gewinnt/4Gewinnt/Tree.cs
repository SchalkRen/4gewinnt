using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{
    public class Tree<T> where T:ITreeElement<T>
    {

        internal class Node<T>
        {
            public T item;
            public Node<T>[] AllKids;
            public Node<T> parent;

        }
        private Node<T> startNode;
        List<List<Node<T>>> allItems = new List<List<Node<T>>> { };

        public Tree(int MaxDepth,T Init)
        {
            initTree(Init, MaxDepth);
        }
        private void initTree(T firstElement, int depth)
        {
            startNode = new Node<T>();
            startNode.item = firstElement;
            
            allItems = new List<List<Node<T>>> {};
            List<Node<T>> firstRow = new List<Node<T>> { startNode };
            allItems.Add(firstRow);
            
            for (int i=0;i<depth;i++)
            {
                List<Node<T>> currentRow = new List<Node<T>> {};
                foreach (Node<T> node in allItems[i])
                {
                    currentRow.AddRange(AddAllChildren(node));
                }
                allItems.Add(currentRow);
               

            }
        }

        public void PrintTree()
        {
            Debug.Print(startNode.ToString());
            PrintAll(startNode);
        }
        private void PrintAll(Node<T> current)
        {
            
            Node<T>[] kids = current.AllKids;
            if(kids!=null)
            {
                foreach (Node<T> kid in kids)
                {
                    Debug.WriteLine(kid.item.ToString());
                    PrintAll(kid);
            }
            }

        }

        Node<T>[] AddAllChildren(Node<T> element)
        {
            T[] allElements = (T[])((element.item.GetAllPossibilities()).Clone());
            Node<T>[] allChildren = new Node<T>[allElements.Length];
           
            for (int i = 0; i < allElements.Length; i++)
            {
                if(allChildren[i]==null)
                {
                    allChildren[i] = new Node<T>();
                }
                allChildren[i].item = allElements[i];
                allChildren[i].parent = element;
            }
            element.AllKids = allChildren;
            return allChildren;
        }


        private MinMaxResult minMaxResult=new MinMaxResult();//The number which is the result of the Min/Max
        public MinMaxResult MinMaxAlgorithmus(bool StartWithMax=true)
        {
            MinMaxStep(startNode, StartWithMax);
            return minMaxResult;

        }

        public class MinMaxResult
        {
            public int hueristik;
            public int nextNumber;
            public T nextItem;

        }

        private int MinMaxStep(Node<T> node,bool UseMax)
        {
            int heuristik = 0;
            if(node.AllKids==null)
            {
               heuristik= node.item.GetHeuristik();
            }
            else if (node.AllKids.Length == 0)
            {
                heuristik = node.item.GetHeuristik();
            }
            else
            {
                
               
                int[] allIntItems = new int[node.AllKids.Length];
                for (int i=0;i<allIntItems.Length;i++)
                {
                    //Node<T>[] copy = (Node<T>[])node.AllKids.Clone();
                    //Node<T> currentNode = copy[i];
                    allIntItems[i] =  MinMaxStep(node.AllKids[i],!UseMax);

                }
                heuristik = UseMax ? allIntItems.Max() : allIntItems.Min();
                node.item.SetHeuristik(heuristik);//Zum besseren Checken
                if (node == startNode)
                {
                    
                    for(int i=0;i<allIntItems.Length;i++)
                    {
                        if(allIntItems[i]==(UseMax ? allIntItems.Max() : allIntItems.Min()))
                        {
                            minMaxResult.nextNumber = i;
                            minMaxResult.nextItem = node.AllKids[i].item;
                            minMaxResult.hueristik = heuristik;
                        }
                    }
                }
            }

            return heuristik;
        }
       
    }

     
}
