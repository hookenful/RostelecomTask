using System;
using System.Collections.Generic;
using Moq;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Services;
using Xunit;

namespace RostelecomTask.Tests
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            IList<Department> departments = new List<Department>
            {
                new Department { Id = 1, Name = "IT"},
                new Department { Id = 2, Name = "KK"},
                new Department { Id = 3, Name = "GG"}
            };


            IList<User> users = new List<User>
            {
                new User { Id = 1, UserName = "proger1",FullName = "Vl1", SettledAt = DateTime.Now},
                new User { Id = 2, UserName = "proger2",FullName = "Vl2", SettledAt = DateTime.Now},
                new User { Id = 3, UserName = "proger3",FullName = "Vl3", SettledAt = DateTime.Now}
            };

        }

        [Fact]
        public void Can_Add_New_User()
        {
            


        }
    }
}
