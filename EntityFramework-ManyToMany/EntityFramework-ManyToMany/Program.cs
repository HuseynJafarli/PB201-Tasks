using EntityFramework_ManyToMany.DAL;
using EntityFramework_ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_ManyToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var brand = new Brand { Name = "BMW" };
            CreateBrand(brand);

            var model = new Model { Name = "F10", BrandId = brand.Id };
            CreateModel(model);

            var color1 = new Color { Name = "Green" };
            var color2 = new Color { Name = "Blue" };
            var color3 = new Color { Name = "Black" };
            CreateColor(color1);
            CreateColor(color2);
            CreateColor(color3);

            var car = new Car
            {
                MaxSpeed = 240,
                FuelTankCapacity = 70,
                Power = 184,
                DoorCount = 4,
                ModelId = model.Id
            };
            CreateCar(car);

            AddColorToCar(car.Id, color1.Id);
            AddColorToCar(car.Id, color2.Id);
            AddColorToCar(car.Id, color3.Id);

            var allCars = GetAllCars();
            foreach (var c in allCars)
            {
                Console.WriteLine($"Id: {c.Id}, Brand: {c.Model.Brand.Name}, Model: {c.Model.Name}, MaxSpeed: {c.MaxSpeed}, FuelTankCapacity: {c.FuelTankCapacity}, Power: {c.Power}, DoorCount: {c.DoorCount}, Colors: {string.Join(", ", c.CarColors.Select(cc => cc.Color.Name))}");
            }
        }

        static void CreateBrand(Brand brand)
        {
            using (var context = new AppDbContext())
            {
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }

        static Brand GetBrandById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Brands.Find(id);
            }
        }

        static List<Brand> GetAllBrands()
        {
            using (var context = new AppDbContext())
            {
                return context.Brands.ToList();
            }
        }

        static void UpdateBrand(Brand brand)
        {
            using (var context = new AppDbContext())
            {
                var existingBrand = context.Brands.Find(brand.Id);
                if (existingBrand != null)
                {
                    existingBrand.Name = brand.Name;
                    context.SaveChanges();
                }
            }
        }

        static void DeleteBrand(int id)
        {
            using (var context = new AppDbContext())
            {
                var brand = context.Brands.Find(id);
                if (brand != null)
                {
                    context.Brands.Remove(brand);
                    context.SaveChanges();
                }
            }
        }

        static void CreateModel(Model model)
        {
            using (var context = new AppDbContext())
            {
                context.Models.Add(model);
                context.SaveChanges();
            }
        }

        static Model GetModelById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Models.Include(m => m.Brand).FirstOrDefault(m => m.Id == id);
            }
        }

        static List<Model> GetAllModels()
        {
            using (var context = new AppDbContext())
            {
                return context.Models.Include(m => m.Brand).ToList();
            }
        }

        static void UpdateModel(Model model)
        {
            using (var context = new AppDbContext())
            {
                var existingModel = context.Models.Find(model.Id);
                if (existingModel != null)
                {
                    existingModel.Name = model.Name;
                    existingModel.BrandId = model.BrandId;
                    context.SaveChanges();
                }
            }
        }

        static void DeleteModel(int id)
        {
            using (var context = new AppDbContext())
            {
                var model = context.Models.Find(id);
                if (model != null)
                {
                    context.Models.Remove(model);
                    context.SaveChanges();
                }
            }
        }

        static void CreateColor(Color color)
        {
            using (var context = new AppDbContext())
            {
                context.Colors.Add(color);
                context.SaveChanges();
            }
        }

        static Color GetColorById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Colors.Find(id);
            }
        }

        static List<Color> GetAllColors()
        {
            using (var context = new AppDbContext())
            {
                return context.Colors.ToList();
            }
        }

        static void UpdateColor(Color color)
        {
            using (var context = new AppDbContext())
            {
                var existingColor = context.Colors.Find(color.Id);
                if (existingColor != null)
                {
                    existingColor.Name = color.Name;
                    context.SaveChanges();
                }
            }
        }

        static void DeleteColor(int id)
        {
            using (var context = new AppDbContext())
            {
                var color = context.Colors.Find(id);
                if (color != null)
                {
                    context.Colors.Remove(color);
                    context.SaveChanges();
                }
            }
        }

        static void CreateCar(Car car)
        {
            using (var context = new AppDbContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        static Car GetCarById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Cars
                    .Include(c => c.Model)
                    .ThenInclude(m => m.Brand)
                    .Include(c => c.CarColors)
                    .ThenInclude(cc => cc.Color)
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        static List<Car> GetAllCars()
        {
            using (var context = new AppDbContext())
            {
                return context.Cars
                    .Include(c => c.Model)
                    .ThenInclude(m => m.Brand)
                    .Include(c => c.CarColors)
                    .ThenInclude(cc => cc.Color)
                    .ToList();
            }
        }

        static void UpdateCar(Car car)
        {
            using (var context = new AppDbContext())
            {
                var existingCar = context.Cars.Find(car.Id);
                if (existingCar != null)
                {
                    existingCar.MaxSpeed = car.MaxSpeed;
                    existingCar.FuelTankCapacity = car.FuelTankCapacity;
                    existingCar.Power = car.Power;
                    existingCar.DoorCount = car.DoorCount;
                    existingCar.ModelId = car.ModelId;
                    context.SaveChanges();
                }
            }
        }

        static void DeleteCar(int id)
        {
            using (var context = new AppDbContext())
            {
                var car = context.Cars.Find(id);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
            }
        }

        static void AddColorToCar(int carId, int colorId)
        {
            using (var context = new AppDbContext())
            {
                var carColor = new CarColor
                {
                    CarId = carId,
                    ColorId = colorId
                };
                context.CarColors.Add(carColor);
                context.SaveChanges();
            }
        }
    }

}

