using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace DataStructures
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Push()
        {
            var list = new DataStructures.List<int>();
            list.Add(1);

            var headInitial = list.GetHeadValue();
            var tailInitial = list.GetTailValue();

            list.Add(2);

            Assert.True(headInitial == tailInitial && 2 == list.GetTailValue() && list.GetHeadValue() != list.GetTailValue() && headInitial == list.GetHeadValue());
        }

        [Test]
        public void Pop()
        {
            var list = new DataStructures.List<int>();
            list.Add(1);

            var headInitial = list.GetHeadValue();
            var tailInitial = list.GetTailValue();

            list.Add(2);

            list.Pop();

            Assert.True(headInitial == tailInitial && tailInitial == list.GetTailValue() && list.GetHeadValue() == list.GetTailValue());
        }

        [Test]
        public void Length()
        {
            var list = new DataStructures.List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);

            var length = list.Length;

            list.Pop();

            Assert.True(length == 3 && list.Length == 2);
        }

        
    }
}
