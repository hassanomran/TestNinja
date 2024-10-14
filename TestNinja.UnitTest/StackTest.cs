using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class StackTest
    {
        //Arrang
        private Fundamentals.Stack<string> _stack;
        [SetUp]
        public void SetUp()
        {
            _stack = new Fundamentals.Stack<string>();
        }
        [Test]
        public void Push_WhenObjectIsUnll_ReturnArgumentNullException() 
        {
            // Assert
            Assert.That(() => _stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());

        }
        [Test]
        public void Push_WhenObjectHaveValue_PushIntoStack()
        {
            //Act
            _stack.Push("Hassan");
            // Assert
            Assert.That(_stack.Count,Is.EqualTo(1));
        }
        [Test]
        public void PopPeek_WhenStackCountIsZero_ReturnArgumentNullException()
        {

            // Assert
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());

        }
        [Test]
        public void Pop_WhenObjectHaveValue_ReturnTheValuseOfTheSelectedStack()
        {
            // Arrang 
            _stack.Push("Hassan");
            _stack.Push("Omran");
            //Act
            var result = _stack.Pop();
            // Assert
            Assert.That(result, Is.EqualTo("Omran"));
        }
        [Test]
        public void Peek_WhenObjectHaveValue_ReturnTheValuseOfTheSelectedStack()
        {
            // Arrang 
            _stack.Push("Hassan");
            _stack.Push("Omran");
            //Act
            var result = _stack.Peek();
            // Assert
            Assert.That(result, Is.EqualTo("Omran"));
        }
    }
}
