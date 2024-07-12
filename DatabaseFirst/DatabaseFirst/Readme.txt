Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql

Scaffold-DbContext "server=localhost;port=3306;database=sakila;user=root;password=12345678x@X" Pomelo.EntityFrameworkCore.MySql -OutputDir Models

services.AddDbContext<sakilaContext>(options =>
    options.UseMySql(
        Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

"ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=sakila;user=root;password=12345678x@X"
  },