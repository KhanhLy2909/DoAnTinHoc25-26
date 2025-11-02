using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Ly_Winf
{
    public class AVLNode
    {
        public int Key;          
        public string[] Data;       
        public AVLNode Left;
        public AVLNode Right;
        public int Height;

        public AVLNode(int key, string[] data)
        {
            Key = key;
            Data = data;
            Height = 1;
        }
    }
}
