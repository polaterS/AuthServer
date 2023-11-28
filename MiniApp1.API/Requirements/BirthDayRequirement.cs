﻿using Microsoft.AspNetCore.Authorization;

namespace MiniApp1.API.Requirements
{
    public class BirthDayRequirement : IAuthorizationRequirement
    {
        public int Age { get; set; }

        public BirthDayRequirement(int age)
        {
            Age = age;
        }
    }

    public class BirthDateRequirementHandler : AuthorizationHandler<BirthDayRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BirthDayRequirement requirement)
        {
            var birthDate = context.User.FindFirst("birth-date");
            if (birthDate == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var today = DateTime.Today;
            var age = today.Year - Convert.ToDateTime(birthDate.Value).Year;

            if(age >= requirement.Age)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
