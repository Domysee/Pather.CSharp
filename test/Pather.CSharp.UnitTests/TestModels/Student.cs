using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pather.CSharp.UnitTests.TestModels
{
    internal class Student
    {
        // 姓名
        public string Name { get; set; }

        public Subject[] Subjects { get; set; }

        public Dictionary<string,double> Skills { get; set; }

        public Dictionary<string,Subject> Scores { get; set; }
    }
}
