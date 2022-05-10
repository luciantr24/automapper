using automapper;
using automapper_unit_tests.TestModels;
using automapper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace automapper_unit_tests
{
    public class First
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class Second
    {
        public string Name { get; set; }
    }
    
    [TestClass]
    public class AutoMapperUnitTests
    {
        [TestMethod]
        public void Mapping_Success()
        {
            var user = new User
            {
                Id = 10000,
                Name = "Test User Name",
                Status = true
            };
            
            var autoMapper = new AutoMapper(config =>
            {
                config.Add<UserDto, User>();
            });

            var userDto = autoMapper.Map<UserDto, User>(user);
            
            Assert.AreEqual(user.Name, userDto.Name);
        }
    }
}