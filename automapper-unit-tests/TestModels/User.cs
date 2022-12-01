using System;

namespace automapper_unit_tests.TestModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        internal DateTime _ts { get; set; } = DateTime.UtcNow;
    }
}