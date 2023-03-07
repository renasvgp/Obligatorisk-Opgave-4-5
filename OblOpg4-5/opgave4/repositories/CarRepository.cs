using obl1;

namespace opgave4.repositories
{

    public class CarRepository
    {

        private int _nextId;
        private List<Car> _cars;

        public CarRepository()
        {
            _nextId = 1;
            _cars = new List<Car>()
            {
                new Car() { Id = _nextId++, Model = "E340", LicensPlate = "045633", Price = 43000 },
                new Car() { Id = _nextId++, Model = "D530", LicensPlate = "034567", Price = 35430 },
                new Car() { Id = _nextId++, Model = "F280", LicensPlate = "153765", Price = 45203 },
                new Car() { Id = _nextId++, Model = "JW45", LicensPlate = "045633", Price = 23467 }

            };




        }
        public List<Car> getAll()
        {
            return new List<Car>(_cars);
        }

        public Car? GetById(int Id)
        {

            return _cars.Find(car => car.Id== Id);

        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextId++;
            _cars.Add(newCar);
            return newCar;
        }

        public Car? Delete(int Id) 
        { 
        Car? foundCar = GetById(Id);
           
            if (foundCar == null)
            {
                return null;


            }

        _cars.Remove(foundCar);
            return foundCar;
        
        }

        public Car? Update(int Id, Car updatedCar)
        {
            updatedCar.Validate();
            Car? carWillUpdate = GetById(Id);
            if (carWillUpdate == null) 
            
            {
                return null;
            }

            carWillUpdate.Model= updatedCar.Model;
            carWillUpdate.LicensPlate= updatedCar.LicensPlate;
            carWillUpdate.Price= updatedCar.Price;
            return carWillUpdate;





        }










    }





}
 



    
