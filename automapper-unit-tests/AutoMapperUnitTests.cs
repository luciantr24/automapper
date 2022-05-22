using automapper;
using automapper_unit_tests.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace automapper_unit_tests
{
    [TestClass]
    public class AutoMapperUnitTests
    {
        private User _userTestData;

        [TestInitialize]
        public void Initialize()
        {
            _userTestData = new User
            {
                Id = 10000,
                Name = "Test Name",
                Status = true
            };
        }

        [TestMethod]
        public void Mapping_Out_In_Success()
        {
            var autoMapper = new AutoMapper(config =>
            {
                config.Add<UserDto, User>();
            });

            var userDto = autoMapper.Map<UserDto, User>(_userTestData);
            
            Assert.AreEqual(_userTestData.Name, userDto.Name);
        }

        [TestMethod]
        public void Mapping_Out_Success()
        {
            var autoMapper = new AutoMapper(config =>
            {
                config.Add<UserDto, User>();
            });

            var userDto = autoMapper.Map<UserDto>(_userTestData);

            Assert.AreEqual(_userTestData.Name, userDto.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Source and Destionation can't be null or empty")]
        public void Mapping_Settings_Null_Or_Empty()
        {
            var autoMapper = new AutoMapper(config => { });

            var result = autoMapper.Map<UserDto, User>(_userTestData);
        }
    }
}