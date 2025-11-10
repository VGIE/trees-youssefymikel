
using System;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;

        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        List<TreeNode<T>> Children;

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Children = new List<TreeNode<T>>();
            Value = value;
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;
        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> newvalue =new TreeNode<T>(value);
            Children.Add(newvalue);
            return newvalue;
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            int count = 1;// we don`t need to know what happend with 0 because it's done  
            for(int i=0; i<Children.Count(); i++)
            {
                count =count+ Children.Get(i).Count();
            }
            return count;
            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            int hTree = 0;
            if (Children.Count() == 0)
            {
                return hTree;
            }

            for (int i = 0; i < Children.Count(); i++)
            {
                hTree = Math.Max(hTree, Children.Get(i).Height());
            }
            return hTree + 1; 
        }

        

        
        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            TreeNode<T> nodefound=null;
            bool vfound = false;
            int i = 0;
            while (i < Children.Count() && vfound==false)
            {
                nodefound = Children.Get(i);
                if (nodefound.Value.Equals(value))
                {
                    Children.Remove(i);
                    vfound = true;
                }
                else
                {
                    nodefound.Remove(value);
                    i++;
                }
            }
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
              if (Value.Equals(value))
            {
                return this;
            }
            else
            {
                int i = 0;
                while (i < Children.Count())
                {
                    TreeNode<T> childfound = Children.Get(i);

                    if (childfound.Value.Equals(value))
                    {
                        return childfound;
                    }
                    else
                    {
                        i++;
                        TreeNode<T> comeback = childfound.Find(value);
                        if (comeback != null)
                        {
                            return comeback;
                        }
                    }

                }
                return null;// if we don`t find the value
            }
            
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            /*TreeNode<T> nodedeleted;
            bool vfound = false;
            int i = 0;
            while(i<Children.Count() && vfound == false)
            {
                nodedeleted = Children.Get(i);
                if (nodedeleted.Value.Equals(value))
                {
                    vfound = true;
                    Children.Remove(i);
                }
                else
                {
                    nodedeleted.Remove(value);
                    i++;
                }
            }*/
            Remove(node.Value);
        }
    }
}