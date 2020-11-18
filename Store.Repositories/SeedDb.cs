using Microsoft.AspNetCore.Identity;
using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Common.Enums;
using Store.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly Random _random;

        public SeedDb(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            this._userRepository = userRepository;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await this._context.Database.EnsureCreatedAsync();

            await this.CheckRoles();

            if (!this._context.Users.Any())
            {
                await this.CheckUserAsync("tony@gmail.com", "Tony", "Stark", UserType.User);
                await this.CheckUserAsync("bruce@gmail.com", "Bruce", "Wayne", UserType.Customer);
                await this.CheckUserAsync("peter@gmail.com", "Peter", "Parker", UserType.Guest);
            }

            var user = await this.CheckUserAsync("eldelbaldio@gmail.com", "Nicolas", "Comaschi", UserType.Admin);

            if (!this._context.Brands.Any())
            {
                this.AddBrand("Bianchi", user);
                this.AddBrand("Cloot", user);
                this.AddBrand("Crysis", user);
                this.AddBrand("Giant", user);
                this.AddBrand("Nordic", user);
                this.AddBrand("Philco", user);
                this.AddBrand("Shifter", user);
                this.AddBrand("Trek", user);
                await this._context.SaveChangesAsync();
            }

            if (!this._context.Presentations.Any())
            {
                this.AddPresentation("Rodado 20", user);
                this.AddPresentation("Rodado 24", user);
                this.AddPresentation("Rodado 26", user);
                this.AddPresentation("Rodado 28", user);
                this.AddPresentation("Rodado 29", user);
                await this._context.SaveChangesAsync();
            }

            if (!this._context.Categories.Any())
            {
                await this.AddCategoriesAndSubsAsync(user);
            }

            if (!this._context.Products.Any())
            {
                this.AddProduct("Crysis TG6N", user, "Varias", "Crysis", "BMX", "Rodado 20", $"~/images/Products/bmx.jpg");
                this.AddProduct("Amma", user, "Varias", "Cloot", "Paseo", "Rodado 26", $"~/images/Products/paseo.jpg");
                this.AddProduct("GTB Elite", user, "Varias", "Nordic", "Plegables", "Rodado 20", $"~/images/Products/plegable.jpg");
                this.AddProduct("Excape Plus", user, "Mountain Bike", "Philco", "Off Road", "Rodado 26", $"~/images/Products/mb1.jpg");
                this.AddProduct("Excape 29", user, "Mountain Bike", "Philco", "Off Road", "Rodado 29", $"~/images/Products/mb2.jpg");
                this.AddProduct("MTB29", user, "Mountain Bike", "Shifter", "Off Road", "Rodado 28", $"~/images/Products/mb3.jpg");
                this.AddProduct("Elite Plus", user, "Ruteras", "Trek", "Competicion", "Rodado 29", $"~/images/Products/ruta1.jpg");
                this.AddProduct("Shapphid", user, "Ruteras", "Bianchi", "Standard", "Rodado 29", $"~/images/Products/ruta2.jpg");
                this.AddProduct("APA-2", user, "Ruteras", "Giant", "Varias", "Rodado 29", $"~/images/Products/ruta3.jpg");
                await this._context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(string email, string firstName, string lastName, UserType userType)
        {
            var user = await this._userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = await this.AddUser(email, firstName, lastName, userType);
                var isInRole = await this._userRepository.IsUserInRoleAsync(user, userType.ToString());
                if (!isInRole)
                {
                    await this._userRepository.AddUserToRoleAsync(user, userType.ToString());
                }
            }
            return user;
        }

        private async Task<User> AddUser(string email, string firstName, string lastName, UserType userType)
        {
             var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                Address = "Calle Falsa 123",
                PhoneNumber = "350 634 2747",
                UserType = userType,
            };

            var result = await this._userRepository.AddUserAsync(user, "123456", userType);
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create the user in seeder");
            }

            await _userRepository.AddUserToRoleAsync(user, userType.ToString());
            var token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            await _userRepository.ConfirmEmailAsync(user, token);
            return user;
        }

        private async Task CheckRoles()
        {
            await this._userRepository.CheckRoleAsync(UserType.Admin.ToString());
            await this._userRepository.CheckRoleAsync(UserType.Customer.ToString());
            await this._userRepository.CheckRoleAsync(UserType.User.ToString());
            await this._userRepository.CheckRoleAsync(UserType.Guest.ToString());
        }

        private void AddBrand(string name, User user)
        {
            this._context.Brands.Add(new Brand
            {
                Name = name,
                User = user,
            });
        }

        private void AddPresentation(string name, User user)
        {
            this._context.Presentations.Add(new Presentation
            {
                Name = name,
                User = user,
            });
        }

        private void AddProduct(string name, User user, string category, string brand, string subcategory, string presentation, string img)
        {
            var c = this._context.Categories.Where(t => t.Name == category).FirstOrDefault();
            var b = this._context.Brands.Where(t => t.Name == brand).FirstOrDefault();
            var s = this._context.Subcategories.Where(t => t.Name == subcategory).FirstOrDefault();
            var p = this._context.Presentations.Where(t => t.Name == presentation).FirstOrDefault();

            this._context.Products.Add(new Product
            {
                Name = name,
                Category = c,
                Subcategory = s,
                Presentation = p,
                Brand = b,
                User = user,
                DateCration = DateTime.Now,
                DateModification = DateTime.Now,
                Discount = this._random.Next(100),
                Price = this._random.Next(1000),
                IsAvailabe = true,
                Remark = "Molestiae expedita veritatis nesciunt doloremque sint asperiores fuga voluptas, distinctio, aperiam, ratione dolore. Ex numquam veritatis debitis minima quo error quam eos dolorum quidem perferendis.Quos repellat dignissimos minus.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Pariatur, vitae, explicabo? Incidunt facere, natus soluta dolores iusto!",
                Size = "Large",
                EspecialPrice = this._random.Next(1000),
                EspecialQuantity = this._random.Next(100),
                ImageUrl = img,
            });
        }

        private async Task AddCategoriesAndSubsAsync(User user)
        {
            this.AddSubcategory("Ruteras", new string[] { "Competicion", "Standard", "Varias" }, user, $"~/images/Categories/ruta.jpg");
            this.AddSubcategory("Varias", new string[] { "Plegables", "Paseo", "BMX" }, user, $"~/images/Categories/varias.jpg");
            this.AddSubcategory("Mountain Bike", new string[] { "Off Road" }, user, $"~/images/Categories/mountain.jpg");
            await this._context.SaveChangesAsync();
        }

        private void AddSubcategory(string category, string[] subcategories, User user, string img)
        {
            var list = subcategories.Select(c => new Subcategory { Name = c, User = user }).ToList();
            this._context.Categories.Add(new Category
            {
                Subcategories = list,
                Name = category,
                User = user,
                ImageUrl = img,
            });
        }
    }
}
