
namespace BST_CA
{
    class TreeNode
    {
        public int key;
        public TreeNode left, right;

        public TreeNode(int item)
        {
            key = item;
            left = right = null;
        }
    }

    public class BinarySearchTree
    {
        TreeNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public bool Search(int key)
        {
            return SearchRecursive(root, key);
        }

        private bool SearchRecursive(TreeNode node, int key)
        {
            if (node == null)
            {
                return false;
            }

            if (node.key == key)
            {
                return true;
            }

            if (key < node.key)
            {
                return SearchRecursive(node.left, key);
            }
            else
            {
                return SearchRecursive(node.right, key);
            }
        }

        // Método para insertar nodos (opcional, pero útil para probar)
        public void Insert(int key)
        {
            root = InsertRecursive(root, key);
        }

        private TreeNode InsertRecursive(TreeNode node, int key)
        {
            if (node == null)
            {
                return new TreeNode(key);
            }

            if (key < node.key)
            {
                node.left = InsertRecursive(node.left, key);
            }
            else if (key > node.key)
            {
                node.right = InsertRecursive(node.right, key);
            }

            return node;
        }

        public bool Delete(int key)
        {
            bool found = false;
            root = DeleteRecursive(root, key, ref found);
            return found;
        }

        private TreeNode DeleteRecursive(TreeNode node, int key, ref bool found)
        {
            if (node == null)
                return null;

            if (key < node.key)
            {
                node.left = DeleteRecursive(node.left, key, ref found);
            }
            else if (key > node.key)
            {
                node.right = DeleteRecursive(node.right, key, ref found);
            }
            else
            {
                found = true;

                // Caso 1: sin hijo o con un solo hijo derecho
                if (node.left == null)
                    return node.right;

                // Caso 2: con un solo hijo izquierdo
                if (node.right == null)
                    return node.left;

                // Caso 3: dos hijos
                TreeNode minNode = FindMin(node.right);
                node.key = minNode.key;
                node.right = DeleteRecursive(node.right, minNode.key, ref found);
            }

            return node;
        }

        private TreeNode FindMin(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        public void InOrder()
        {
            InOrderRecursive(root);
            Console.WriteLine();
        }

        private void InOrderRecursive(TreeNode node)
        {
            if (node != null)
            {
                InOrderRecursive(node.left);
                Console.Write(node.key + " ");
                InOrderRecursive(node.right);
            }
        }

        public void PreOrder()
        {
            PreOrderRecursive(root);
            Console.WriteLine();
        }

        private void PreOrderRecursive(TreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                PreOrderRecursive(node.left);
                PreOrderRecursive(node.right);
            }
        }

        public void PostOrder()
        {
            PostOrderRecursive(root);
            Console.WriteLine();
        }

        private void PostOrderRecursive(TreeNode node)
        {
            if (node != null)
            {
                PostOrderRecursive(node.left);
                PostOrderRecursive(node.right);
                Console.Write(node.key + " ");
            }
        }


    }


}