using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearning
{
    [Serializable]
    public class Node
    {
        public enum NodeType
        {
            Question,   // в узле вопрос
            Object      // в узле объект (листовой терминальный) узел
        }


        Node left;  // да
        Node right; // нет

        Node parent;

        string question;

        public Node Left
        {
            get { return left; }
            set {
                Console.WriteLine("Node {0} Left set to {1}", Question, value);
                left = value; 
            }
        }

        public Node Right
        {
            get { return right; }
            set {
                Console.WriteLine("Node {0} Right set to {1}", Question, value);
                right = value; 
            }
        }

        public Node Parent
        {
            get { return parent; }
            set {
                Console.WriteLine("Node {0} Parent set to {1}", Question, value);
                parent = value; 
            }
        }

        public string Question
        {
            //get { if (isLeaf) return question + "!"; else return question + "?"; }
            get { if (isLeaf) return question; else return question; }
            set { question = value; }
        }
        

        public NodeType Type {
            get
            {
                if (isLeaf) return NodeType.Object; else return NodeType.Question;
            }
        }

        public bool isLeaf 
        {
            get { if (left == null && right == null) return true; else return false; }
        }

        public Node()
        {
        }

        public Node(Node l, Node r, Node p, string q)
        {
            left    =   l;
            right   =   r;
            parent  =   p;
            Question =  q;
        }

        public Node(string q)
        {
            Question = q;
        }

        public int answer;

        public override string ToString()
        {
            return Question;
        }


        
    }
}
