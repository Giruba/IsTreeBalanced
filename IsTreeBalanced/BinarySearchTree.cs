using System;
using System.Collections.Generic;
using System.Text;

namespace IsTreeBalanced
{
    class BinarySearchTree
    {
        BinaryTreeNode rootNode;

        public BinarySearchTree() { }

        public void SetRootNode(BinaryTreeNode node) {
            rootNode = node;
        }

        public BinaryTreeNode GetRootNode() {
            return rootNode;
        }


        public void Insert(int data) {
            rootNode = _InsertUtil(rootNode, data);
        }

        private BinaryTreeNode _InsertUtil(BinaryTreeNode binaryTreeNode, int data) {

            if (binaryTreeNode == null) {
                binaryTreeNode = new BinaryTreeNode(data);
                return binaryTreeNode;
            }

            if (binaryTreeNode.GetData() < data)
            {
                binaryTreeNode.SetRightNode(
                    _InsertUtil(binaryTreeNode.GetRightNode(), data));
            }
            else {
                binaryTreeNode.SetLeftNode(
                    _InsertUtil(binaryTreeNode.GetLeftNode(), data));
            }


            return binaryTreeNode;
        }

        //InOrder Traversal - Left Root and Right
        public void InorderTraversal(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return;
            }
            InorderTraversal(binaryTreeNode.GetLeftNode());
            Console.WriteLine(binaryTreeNode.GetData() + "->");
            InorderTraversal(binaryTreeNode.GetRightNode());
        }

        //PreOrder Traversal - Root and then children
        public void PreOrderTraversal(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return;
            }

            Console.WriteLine(binaryTreeNode.GetData() + "->");
            PreOrderTraversal(binaryTreeNode.GetLeftNode());
            PreOrderTraversal(binaryTreeNode.GetRightNode());
        }

        //PostOrderTraversal - Root and then children
        public void PostOrderTraversal(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return;
            }

            PostOrderTraversal(binaryTreeNode.GetLeftNode());
            PostOrderTraversal(binaryTreeNode.GetRightNode());
            Console.WriteLine(binaryTreeNode.GetData() + "->");
        }

        public bool isTreeBalanced(BinaryTreeNode binaryTreeNode) {

            if (binaryTreeNode == null) {
                return true;
            }

            bool isLeftBalanced = isTreeBalanced(binaryTreeNode.GetLeftNode());
            if (!isLeftBalanced) {
                return false;
            }
            bool isRightBalanced = isTreeBalanced(binaryTreeNode.GetRightNode());
            if (!isRightBalanced) {
                return false;
            }
            int heightAtRoot = HeightOfTree(binaryTreeNode.GetLeftNode()) - 
                               HeightOfTree(binaryTreeNode.GetRightNode());

            if (heightAtRoot >= 0 && heightAtRoot < 2) {
                return true;
            }

            return false;
        }

        public int HeightOfTree(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return 0;
            }

            int leftHeight = HeightOfTree(binaryTreeNode.GetLeftNode());
            int rightHeight = HeightOfTree(binaryTreeNode.GetRightNode());

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
