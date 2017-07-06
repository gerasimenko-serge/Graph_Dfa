using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphView
{
    public delegate void MouseHandler(IView sender);
    
    public interface IView
    {
        
        void Draw(Graphics g);
    }
}
