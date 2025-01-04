using System.Reflection.Metadata;
using System.Xml;
using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Contexts;
using web.bueno.crm.infraestructure.Repositories;
using Moq;
using Microsoft.EntityFrameworkCore;
using web.bueno.crm.unittest.Tools;
using NSubstitute.ReturnsExtensions;
using NSubstitute;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using web.bueno.crm.aplication.Common;
using System;

namespace web.bueno.crm.unittest
{
    public class TestContactoServicio
    {

        [Fact]
        public async void guardar_contacto_usando_bd_en_memoria()
        {

            var options = new DbContextOptionsBuilder<CrmLiaContext>()
            .UseInMemoryDatabase(databaseName: "TempDatabase")
            .Options;

            var context = new CrmLiaContext(options);

            var contactoRepository = new ContactoRepository(context);
            var create = new Contacto()
            {
                Nombres = "Test 1",
                ApellidoMaterno = "Materno",
                ApellidoPaterno = "Paterno",
                FechaCreacion = DateTime.Now
            };

            bool result = await contactoRepository.CrearContacto(create);

            Assert.True(result, DateTime.Now.ToString());
        }

        [Fact]
        public async void guardar_contacto_usando_mock_metodo()
        {

            DbContextOptions<CrmLiaContext> mockOptions = new();
            var context = new Mock<CrmLiaContext>(mockOptions);

            Mock<DbSet<Contacto>> mockDbSet = new();
            context.Object.Contacto = mockDbSet.Object;
            context.Setup(c => c.Contacto).Returns(mockDbSet.Object);


            var contactoRepository = new ContactoRepository(context.Object);
            var create = new Contacto()
            {
                Nombres = "Test 2",
                ApellidoMaterno = "Materno",
                ApellidoPaterno = "Paterno",
                FechaCreacion = DateTime.Now
            };

            bool result = await contactoRepository.CrearContacto(create);

            mockDbSet.Verify(c => c.AddAsync(It.IsAny<Contacto>(), It.IsAny<CancellationToken>()), Times.Once);

        }

        [Fact]
        public async void guardar_contacto_usando_mock_entity()
        {
            var create = new Contacto()
            {
                Nombres = "Test",
                ApellidoMaterno = "Materno",
                ApellidoPaterno = "Paterno",
                FechaCreacion = DateTime.Now
            };

            var dataSource = new List<Contacto>();
            DbContextOptions<CrmLiaContext> mockOptions = new();

            var context = new Mock<CrmLiaContext>(mockOptions);

            context.Setup(m => m.Contacto.AddAsync(It.IsAny<Contacto>(), default))
             .Callback<Contacto, CancellationToken>((s, token) => { dataSource.Add(s); });

            context.Setup(c => c.SaveChangesAsync(default))
                        .Returns(Task.FromResult(1))
                        .Verifiable();

            var contactoRepository = new ContactoRepository(context.Object);
            var result = await contactoRepository.CrearContacto(create);

            Assert.True(result, DateTime.Now.ToString());
        }


    }
}