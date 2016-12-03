using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftEngProject;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftEng_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void cbxFill_Test()
        {
            
        }

        [TestMethod]
        public void tbxAddText_Test()
        {
            Preview testPrev = new Preview();
            testPrev.Show();
            // Replace with randomly-generated string?
            string[] testText = {"To be or not to be, that is the question","Whether 'tis nobler in the mind to suffer","The slings and arrows of outrageous fortune"};
            for (int i = 0; i < testText.Length; i++)
            {
                testPrev.AddText(testText[i]);
            }
        }
    }
}
   