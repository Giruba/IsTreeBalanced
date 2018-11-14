using System;

namespace IsTreeBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check the balance of a tree!");
            Console.WriteLine("----------------------------");
            try
            {
                BinarySearchTree binarySearchTree = ConstructTree();
                if (binarySearchTree.isTreeBalanced(binarySearchTree.GetRootNode()))
                {
                    Console.WriteLine("-------------Result------------");
                    Console.WriteLine("Entered tree is Balanced!");
                }
                else {
                    Console.WriteLine("Entered tree is not balanced!");
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown Exception is "+exception.Message);
            }

            Console.ReadLine();
        }

        private static BinarySearchTree ConstructTree() {
            BinarySearchTree binarySearchTree = null;
            Console.WriteLine("Enter the number of nodes in the Tree");
            try
            {
                int noOfElements = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the elements separated by space");
                String[] elements = Console.ReadLine().Split(' ');
                binarySearchTree = new BinarySearchTree();
                for (int i = 0; i < noOfElements; i++) {
                    binarySearchTree.Insert(int.Parse(elements[i]));
                }

            }catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            return binarySearchTree;
        }
    }
}
