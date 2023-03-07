using Microsoft.VisualStudio.TestTools.UnitTesting;
using opgave4.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using obl1;

namespace opgave4.repositories.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {
        [TestMethod()]
        public void GetAllTests()
        {
            CarRepository repository = new CarRepository();

            List<Car> cars = repository.getAll();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() > 0);
        }

    

        [TestMethod()]
        public void GetByIdTest()
        {
            CarRepository repository = new CarRepository();

            Car? car = repository.GetById(1);

            Assert.IsNotNull(car);
            Assert.AreEqual(1, car.Id);
            Assert.AreNotEqual ("E340", car.LicensPlate);
        }
    }

        
    
}