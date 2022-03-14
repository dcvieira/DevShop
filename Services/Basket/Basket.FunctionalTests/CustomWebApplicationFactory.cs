using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Basket.FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public CustomWebApplicationFactory()
        {

        }
    }
}
