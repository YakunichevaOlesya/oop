using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    class Comment
    {
        public readonly Worker Author;
        public readonly DateTime Date;
        public readonly string Text;

        public Comment(Worker worker, string text)
        {
            Author = worker;
            Date = DateTime.Now;
            Text = text;
        }
    }
}
