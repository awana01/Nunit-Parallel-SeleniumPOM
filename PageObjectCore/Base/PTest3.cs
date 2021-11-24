using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PageObjectCore.Base
{
    [Parallelizable(ParallelScope.All)]
    public class PTest3
    {

        [Test]
        [TestCase("abc", TestName = "Simple Value1", Description = "This test uses a simple input value1")]
        [TestCase("efg", TestName = "Simple Value2", Description = "This test uses a simple input value1")]
        public void TestIt(string value)
        {
            var name = Faker.Name.FullName(); // Tod Yundt
            Console.WriteLine("Full Name:" + name);
            Console.WriteLine("Data Value: " + value);


            var firstName = Faker.Name.First(); // Orlando
            var lastName = Faker.Name.Last(); // Brekke
            var address = Faker.Address.StreetAddress(); // 713 Pfeffer Bridge
            var city = Faker.Address.City(); // Reynaton
            var number = Faker.RandomNumber.Next(100); // 30
            var dob = Faker.Identification.DateOfBirth(); // 1971-11-16T00:00:00.0000000Z

            // US - United States
            var ssn = Faker.Identification.SocialSecurityNumber(); // 249-17-9666
            var mbi = Faker.Identification.MedicareBeneficiaryIdentifier(); // 8NK0Q74KT53
            var usPassport = Faker.Identification.UsPassportNumber(); // 335587506

            // UK - United Kingdom
            var nin = Faker.Identification.UkNationalInsuranceNumber(); // YA171053Y
            var ninFormatted = Faker.Identification.UkNationalInsuranceNumber(true); // YA 17 10 53 Y
            var ukPassport = Faker.Identification.UkPassportNumber(); // 496675685
            var ukNhs = Faker.Identification.UkNhsNumber(); // 6584168301
            var ukNhsFormatted = Faker.Identification.UkNhsNumber(true); // 658 416 8301

            // BG - Bulgaria
            var bulgarianPin = Faker.Identification.BulgarianPin(); //6402142606



        }

        [TestCaseSource(nameof(DivideCases))]
        public void DivideTest1(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        static object[] DivideCases =
        {
           new object[] { 12, 3, 4 },
           new object[] { 12, 2, 6 },
           new object[] { 12, 4, 3 }
        };

        [TestCaseSource(typeof(AnotherClass), nameof(AnotherClass.DivideCases))]
        public void DivideTest2(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }


        static int[] EvenNumbers = new int[] { 2, 4, 6, 8 };

        [Test, TestCaseSource(nameof(EvenNumbers))]
        public void TestMethod(int num)
        {
            Assert.IsTrue(num % 2 == 0);
        }

        



        static string name = "equal";

        [Test]
        [Repeat(5)]
        //[TestCaseSource(nameof(name))]
        public void MyTestX()
        {
            string name = "";

            if (name.Equals(""))
               name= Faker.Name.First();
            

            Random r = new Random();
            int rInt = r.Next(5000,10000); //for ints
            Console.WriteLine("Faker: " + name+" wait for: "+rInt+" secs");
            Thread.Sleep(rInt);
        }

         [Test, Sequential]
         public void MyTestSeq01(
                                  [Values("fname")] string fname, 
                                  [Values("lname")] string lname
                                )
         {
           


         }

         

    }

    public class AnotherClass
    {
        public static object[] DivideCases =
        {
           new object[] { 12, 3, 4 },
           new object[] { 12, 2, 6 },
           new object[] { 12, 4, 3 }
        };
    }


}
